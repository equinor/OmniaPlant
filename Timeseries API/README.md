# Omnia Timeseries API

OpenAPI documentation is available at: **URL**

The Omnia Timeseries API is used to create, update and read timeseries metadata and data in Omnia. 
A timeseries consists of a sequence of data points, such as a heat exchanger having a temperature timeseries that records a data point in units of °C every second. 

The API is RESTful that uses the HTTP requests GET, PUT, POST and PATCH to get and manage data, and the payload is encoded in JSON. This is because REST APIs are easily available without need for specialized software or drivers to connect. It is easy for web applications and any other software that can communicate over the internet to gain access and use the API, independent of platform.

The API shall speak the same language as its users, the user shall know what functionality to expect from each endpoint and it shall be simple to get up to speed on how to use the API. The data fields shall capture the very essence of the domain objects, and not the underlying implementation details from the source system. 

The API versioning is following Semantic Versioning - https://semver.org/

The Timeseries API uses OAuth 2.0 and supports both user authentication (OAuth 2.0 authorization code grant) and service-to-service authentication (OAuth 2.0 client credentials grant).

All date and time information (i.e. timestamps) are based on UTC (Universal Time Coordinated) and formatted according to RFC3339: *YYYY-MM-DDThh:mm:ss.mmmZ*
