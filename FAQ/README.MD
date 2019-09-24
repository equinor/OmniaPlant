# Frequently Asked Questions

### Access
**Q:** How do I get access to the Omnia Timeseries API?<br>
**A:** Take a look at https://github.com/equinor/OmniaPlant/wiki/Authentication-&-Authorization

**Q:** Do I need an Equinor account to use the API?<br>
**A:** To authenticate towards the API with user impersonation, i.e. a software authenticates on behalf you as a person, you need an Equinor account. For service-to-service (m2m) you don't need any Equinor account. You only need access to Internet and include the client credentials (client id and client secret) that we provide you.

### Timeseries Data
**Q:** What is the publishing rate on the timeseries data in the Omnia Timeseries API, i.e. how often is the data refreshed?<br>
**A:** For timeseries data originating from the on-premises Historians, the publishing rate is 5 minutes, i.e. data is refreshed every 5 minutes. For the Peregrino plant, the publishing rate is 10 minutes.

**Q:** In the Omnia Timeseries API, will I find all timeseries ("tags") that exist in the on-premises Historians?<br>
**A:** No, timeseries ("tags") is made available in the Omnia Timeseries DB and Omnia Timeseries API case by case, so it is use case driven. 

**Q:** How much history do you make available in the Omnia Timeseries API?<br>
**A:** We currently don't have any retention policies in the Omnia Timeseries DB. For timeseries data coming from the on-premise Historians we backfill 120 days of history when we start streaming the microbatches to Omnia. The backfill is running every midnight. 

### Omnia Timeseries API versus Data Lake
**Q:** Do I get the exact same timeseries with data points in both the Omnia Timeseries API and the Data Lake?<br>
**A:** No, not necessarily. When the timeseries data is coming from the on-premises Historians, i.e. the source is the same, making data available in Data Lake and Omnia Timeseries DB w/ Omnia Timeseries API is two independent services. You may have timeseries in Data Lake which is not available in Omnia Timeseries API and vice versa. 

### Context
**Q:** Is there an asset model / equipment hierarchy API that can be used to easily find and understand the timeseries data?<br>
**A:** No, the Omnia Timeseries API itself only provides "flat" timeseries objects without any other context than the name, description, engineering unit and the plant the timeseries is linked to.
