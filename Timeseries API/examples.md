## Examples

### Get timeseries by id = {id}:
```
GET https://<url>/timeseries/<version>/timeseries/{id}
Host: api.equinor.com
Authorization: <access token>
```
And you will get the response:
```
  "data": {
    "items": [
      {
        "assetId": "",
        "changedTime": "2019-01-17T08:25:59.995Z",
        "createdTime": "2019-01-17T08:25:59.995Z",
        "description": "",
        "externalId": "",
        "id": "{id}",
        "name": "23PT1234",
        "step": true,
        "unit": ""
      }
    ]
  }
}
```
### Get timeseries by name = 23PT1234:
```
GET https://<url>/timeseries/<version>/timeseries?name=23PT1234 HTTP/1.1
Host: api.equinor.com
Authorization: <access token>
```
### Get timeseries by externalId = {external id}:
```
GET https://<url>/timeseries/<version>/timeseries/?externalId={externalId}
Host: api.equinor.com
Authorization: <access token>
```

