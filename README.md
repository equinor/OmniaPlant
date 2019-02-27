# Omnia Plant Data Platform
The Omnia Plant Data Platform is Equinor's platform for accessing contextualized industrial data from Equinor plants. All data and functionality are made available through open APIs so you can spend your time developing applications, applying analytics and accelerate/scale your digital initiatives. The platform is supporting and enabling many of Equinor's major projects on the digital roadmap such as Integrated Operations Centre (IOC) and Digital Twin/AR/VR, and it is also used for bi-directional data sharing with external suppliers.

![Screenshot](/.attachments/Building_blocks.JPG)

The current building blocks in the platform is centered around timeseries metadata and data. It consists of services to export and stream timeseries data and metadata from a number of different timeseries data sources both internally and externally. Data and functionality in Omnia Plant Data Platform is exposed by using APIs that both internal and external customers can use to build new value-adding application and services. 

The APIs are products themselves in the Omnia Plant Data Platform, and we adhere to the following overall data sharing principles:
* All data sharing will happen through open, well-documented (using OpenAPI) and versioned APIs.
* All data needs to be searchable.
* Customers writing data back to Omnia Plant Data Platform shall provide it in a machine-readable format (that can be automatically read and processed by a computer).
* No underlying technology will be exposed through the API - to ensure a continuous optimization of the backend.
* APIs are defined and developed iteratively, driven by concrete use cases with business value.

The Omnia Plant Data Platform is also adhering to Equinor's API strategy: https://github.com/equinor/api-strategy

## Working mode
The team building the platform operates in two-week sprints, and a product goes through Alpha, Beta, General Available (GA) and Deprecation phases. When a product is released in Beta, invited customers and stakeholders will test and provide feedback on the product. When the product is General Available (put into production) customers can expect standard technical support according to Service Level Agreement (SLA), and full documentation will be available. 

A product or feature will be available and supported 12 months after customers have been notified that it will be removed. Deprecation takes for instance place when there is a new major release. The previous version can then be used and will be supported for 12 months before it is taken out of production. 


