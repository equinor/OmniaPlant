```
var clientId = pm.variables.get("clientId");

var clientSecret = pm.variables.get("clientSecret");

var resource = pm.variables.get("resource");

if (!clientId || !clientSecret || !resource) return;

 

var currentResourceId = pm.globals.get("currentResourceId");

var currentClientId = pm.globals.get("currentClientId");

var expiresOn = pm.globals.get("accessTokenExpiry");

if (currentResourceId == resource &&

    clientId == currentClientId &&

    expiresOn && Date.now() < expiresOn*1000) return;

 

function urlEncode(obj) {

    var keys = Object.keys(obj), qParams = [];

    for (var i = 0; i < keys.length; i++) {

        qParams.push(keys[i] + "=" + encodeURIComponent(obj[keys[i]]));

    }

    return qParams.join("&");

}

const tokenRequest = {

  url: 'https://login.microsoftonline.com/3aa4a235-b6e2-48d5-9195-7fcf05b459b0/oauth2/token',

  method: 'POST',

  header: [

    'Content-Type: application/x-www-form-urlencoded',

    'Accept: application/json'

  ],

  body: {

    mode: 'raw',

    raw: urlEncode({

      resource: resource,

      client_id: clientId,

      client_secret: clientSecret,

      grant_type: "client_credentials"

    })

  }

}

pm.sendRequest(tokenRequest, function (err, response) {

    var jsonResult = response.json();

    if (err) {

        console.log(jsonResult);

    } else {

        pm.globals.set("currentAccessToken", jsonResult.access_token);

        pm.globals.set("accessTokenExpiry", jsonResult.expires_on);

        pm.globals.set("currentClientId", clientId);

        pm.globals.set("currentResourceId", resource);

        pm.globals.set("tokenExpireDate", new Date(jsonResult.expires_on*1000).toISOString());

    }

});
```
