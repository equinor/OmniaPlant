# Authentication & Authorization

The Timeseries API uses Azure AD 1.0 endpoint as identity provider which means that Azure AD is responsible to verify the identity of 
users and applications and issue access tokens upon successful authentication. 
More documentation on Azure AD is found here: https://docs.microsoft.com/en-us/azure/active-directory/develop/v1-overview

The Azure Active Directory Authentication Library (ADAL) v1.0 enables developers to authenticate users and applications to Omnia, 
and obtain tokens for using the Omnia Timeseries API. An overview of Microsoft-support ADAL client libraries is found here: 
https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-authentication-libraries

The Omnia Plant team will register you as a customer and you will get a client id and secret for your client that will call the API. 
One customer can have several client applications using the API. To get a token, your client needs to provide the resource id of the 
Timeseries API, your client id and client secret. If your client has been granted access to the API with a given role, a valid token 
from Azure AD will be returned. This token is included in the HTTP Authorization header when calling the Omnia Timeseries API.
