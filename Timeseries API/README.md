# Omnia Timeseries API

The Omnia Timeseries API is used to create, update and read timeseries metadata and data in Omnia. 
A timeseries consists of a sequence of data points, such as a heat exchanger having a temperature timeseries that records a data point in units of °C every second. 

The API is RESTful that uses the HTTP requests GET, PUT, POST and PATCH to get and manage data, and the payload is encoded in JSON.
The API versioning is following Semantic Versioning - https://semver.org/

OpenAPI documentation is available at: **URL**

The Timeseries API uses OAuth 2.0 and supports both user authentication (OAuth 2.0 authorization code grant) and service-to-service authentication (OAuth 2.0 client credentials grant).

## Timeseries Metadata

A customer of Omnia Plant Platform must first create timeseries metadata before we accept a live timeseries data stream, this is to ensure that Omnia don't provide data without metadata. 

A customer is at least required to include a name of the timeseries being created. A timeseries name is not used as a unique identifier, the Omnia Plant Platform assigns automatically a unique identifier for each timeseries that remains the same throughout the timeseries lifecycle. 

A customer is at least able to get timeseries metadata by the unique identifier, by timeseries name or by externalId. The external id is usually an internal system identifier provided by the customer. 

Current timeseries metadata fields:
- name: name of the timeseries
- description: description of the timeseries
- step: whether the timeseries is step or not - true/false. When interpolating between data points, you can assume that for a stepped timeseries each value stays the same until the next measurement.
- unit: units of measurement of the timeseries
- assetId: id of the asset this timeseries belongs to (optional free text string field until asset model service is in place)
- externalId: id from another (external) system provided by client.

## Timeseries Data (in-progress)

API endpoint for timeseries data is currently in alpha phase.

## Authentication & Authorization

The Timeseries API uses Azure AD 1.0 endpoint as identity provider which means that Azure AD is responsible to verify the identity of users and applications and issue access tokens upon successful authentication. More documentation on Azure AD is found here: https://docs.microsoft.com/en-us/azure/active-directory/develop/v1-overview

The Azure Active Directory Authentication Library (ADAL) v1.0 enables developers to authenticate users and applications to Omnia, and obtain tokens for using the Omnia Timeseries API. An overview of Microsoft-support ADAL client libraries is found here: https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-authentication-libraries

The Omnia Plant team will register you as a customer and you will get a client id and secret for your client that will call the API. One customer can have several client applications using the API. To get a token, your client needs to provide the resource id of the Timeseries API, your client id and client secret. If your client has been granted access to the API with a given role, a valid token from Azure AD will be returned. This token is included in the HTTP Authorization header when calling the Omnia Timeseries API.
