# Frequently Asked Questions

### General
**Q:** I have a project where we are going to share timeseries ("sensor data") data externally, e.g. with partners and/or suppliers. Which solution do you recommend?<br>
**A:** We need to understand the use case and needs, but in general we recommend the Omnia Timeseries API as a base case because:<br>
* The API is secured by design and implemented according to our information security requirements.
* The API is internet-facing and made for public use, it works equally for external as it does for internal customers. The API can be accessed from any platform and software environment as long as you have access to Internet. There is no need for proprietary point-to-point integrations over VPN etc. forcing both parties to implement licensed and vendor-specific software.
* The API itself is managed as a key product. It means we put high focus on the customers of the API (e.g. developers) trying to make their user experience as best as possible and we are eager to get feedback that we can use to continuously improve it.
* The API don't expose any inner workings, implementation details or internal vendor-specific name schemes from the underlying technology. We can then ensure a continuous optimization of the backend without breaking all clients using the API (agility). We can also start focusing on industry collaboration and interoperability, many companies have different software solutions, and you can't collaborate on common information models with the mindset "we use vendor software A, so it has to be like that", and "we use vendor software B, so it has to be like that".
* The API provides both data and operations (aggregations) in response to query parameters.
* The API supports queries where you e.g. only want to get a subset of the data at a certain granularity. This is out of the box. 
* APIs are a core element of any digital business platform. It is the interface between applications, data and services. Equinor is heading in a "API first" direction - we require software components to provide APIs to communicate with other components, share data and functionality - this is anchored in governing requirements and our API strategy available at https://github.com/equinor/api-strategy
* APIs can be re-used across the organization, internally and externally, meaning that each development team don't have to build processing capabilities from scratch. APIs are increasing the efficiency in software development.

### Access
**Q:** How do I get access to the Omnia Timeseries API?<br>
**A:** Take a look at https://github.com/equinor/OmniaPlant/wiki/Authentication-&-Authorization

**Q:** Do I need an Equinor account to use the API?<br>
**A:** To authenticate towards the API with user impersonation, i.e. a software authenticates on behalf you as a person, you need an Equinor account. For service-to-service (m2m) you don't need any Equinor account. You only need access to Internet and include the client credentials (client id and client secret) that we provide you.

### Timeseries Data
**Q:** What is the publishing rate on the timeseries data in the Omnia Timeseries API, i.e. how often is the data refreshed?<br>
**A:** For timeseries data originating from the on-premise Historians, the publishing rate is 5 minutes, i.e. data is refreshed every 5 minutes. For the Peregrino plant, the publishing rate is 10 minutes.

**Q:** In the Omnia Timeseries API, will I find all timeseries ("tags") that exist in the on-premise Historians?<br>
**A:** No, timeseries ("tags") are made available in the Omnia Timeseries DB and Omnia Timeseries API case by case, so it is use-case driven. That said, in the Omnia Timeseries API you will also find data that don't exist in the on-premise Historians, such as new derived and calculated data from projects. 

**Q:** How much history do you make available in the Omnia Timeseries API?<br>
**A:** We currently don't have any retention policies in the Omnia Timeseries DB. For timeseries data coming from the on-premise Historians we backfill 120 days of history when we start streaming the microbatches to Omnia. The backfill is running every midnight.

### Timeseries Metadata
**Q:** What happens in Omnia Timeseries API if timeseries metadata (name, description, unit) changes in the source system?<br>
**A:** If a timeseries name ("tag name") is changed (renamed) in the on-premise Historians (OSISoft PI and AspenTech IP.21), the corresponding name will be updated in Omnia and be reflected in the Omnia Timeseries API. The same goes for description and unit. We are not able to automatically detect if someones decides to do the renaming by creating a new timeseries ("tag") in the on-premises Historian. This new tag must be treated as a new timeseries and work must be done to make it and its data available in Omnia. When customers write new timeseries data to Omnia Timeseries API, it is their responsibility to keep metadata updated. 

### Omnia Timeseries API versus Data Lake
**Q:** Do I get the exact same timeseries with data points in both the Omnia Timeseries API and the Data Lake?<br>
**A:** No, not necessarily. When the timeseries data is coming from the on-premise Historians, i.e. the source is the same, making data available in Data Lake and Omnia Timeseries DB w/ Omnia Timeseries API is two independent services. You may have timeseries in Data Lake which is not available in Omnia Timeseries API and vice versa. 

**Q:** When shall I use the Data Lake and when shall I use the Omnia Timeseries API?<br>
**A:** The Omnia Timeseries API ("online") is an interface to access the Omnia Timeseries DB. The Omnia Timeseries DB is optimized for large volumes of timeseries data with the ability to perform near real-time queries and analysis on those data. The Omnia Timeseries API therefore supports fast random ad-hoc queries, e.g. among many distinct timeseries I want to see data on Timeseries A, B and C from 12:00 to 12:15. The Omnia Timeseries API also gives you the ability to get aggregated data (max, min, avg, stddev and count) out of the box. A typical primary measure for the Omnia Timeseries API is response time, i.e. for how long do you need to wait for a response on your API request.

The Data Lake on the other hand is for batch processing ("offline") where you take a large amount of input data (e.g. 10 years of timeseries data from a huge number of distinct timeseries), runs a job to process it and produce some output data. These jobs take a while, from hours to days. A typical primary measure for the Data Lake is not response time, but throughput (the number of timeseries and volume of timeseries data we can process per time unit, or the total time it takes to run a job on a dataset of a certain size). When reading files in a distributed file system you scan the entire file which is inefficient if you only want to access a short timespan on a specific timeseries (this is what the Omnia Timeseries API is designed for). Accessing timeseries data in the Data Lake is typically used for training of machine learning models, i.e. batch processing.

### Context
**Q:** Is there an asset model / equipment hierarchy API that can be used to easily find and understand the timeseries data?<br>
**A:** No, the Omnia Timeseries API itself only provides "flat" timeseries objects without any other context than the name, description, engineering unit and the plant the timeseries is linked to.
