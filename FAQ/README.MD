# Frequently Asked Questions

### Access
**Q:** How do I get access to the Omnia Timeseries API?<br>
**A:** Take a look at https://github.com/equinor/OmniaPlant/wiki/Authentication-&-Authorization

**Q:** Do I need an Equinor account to use the API?<br>
**A:** To authenticate towards the API with user impersonation, i.e. a software authenticates on behalf you as a person, you need an Equinor account. For service-to-service (m2m) you don't need any Equinor account. You only need access to Internet and provide the client credentials (client id and client secret) that we provide you.

### Timeseries Data
**Q:** What is the publishing rate on the timeseries data in the Omnia Timeseries API, i.e. how often is the data refreshed?<br>
**A:** For timeseries data originating from the on-premises Historians, the publishing rate is 5 minutes, i.e. data is refreshed every 5 minutes. For the Peregrino plant, the publishing rate is 10 minutes.

### Context
**Q:** Is there an asset model / equipment hierarchy API that can be used to easily find and understand the timeseries data?<br>
**A:** No, the Omnia Timeseries API itself only provides "flat" timeseries objects without any other context than the name, description, engineering unit and the plant the timeseries is linked to.
