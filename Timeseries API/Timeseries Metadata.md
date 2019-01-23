# Timeseries Metadata

A customer of Omnia Plant Platform must first create timeseries metadata before we accept a live timeseries data stream, this is to 
ensure that Omnia don't provide data without metadata. A customer is at least required to include a name of the timeseries being created. 
A timeseries name is not used as a unique identifier, the Omnia Plant Platform assigns automatically a unique identifier for each 
timeseries that remains the same throughout the timeseries lifecycle. 

A customer is at least able to get timeseries metadata by the unique identifier, by timeseries name or by externalId. 
The external id is usually an internal system identifier provided by the customer. 

Current timeseries metadata fields:
- name: name of the timeseries
- description: description of the timeseries
- step: whether the timeseries is step or not - true/false. When interpolating between data points, you can assume that for a stepped timeseries each value stays the same until the next measurement.
- unit: units of measurement of the timeseries
- assetId: id of the asset this timeseries belongs to (optional free text string field until asset model service is in place)
- externalId: id from another (external) system provided by client.
