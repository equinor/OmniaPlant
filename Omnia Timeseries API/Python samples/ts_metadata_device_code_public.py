import json
import logging
import os
import sys
import adal
import requests

def turn_on_logging():
    logging.basicConfig(level=logging.DEBUG)

# OAuth 2.0 Authorization Code Flow for user impersonation without any secret

parameters_file = {
    #This is the resource id of the Timeseries API, provided by Omnia Plant
    'resource': '', 
    #This is the Equinor Azure AD tenant id, provided by Omnia Plant
    'tenant': '', 
    #This is the authority host where authentication requests are served
    'authorityHostUrl': 'https://login.microsoftonline.com', 
    #This is the client/application id of your client app registered in Equinor's Azure AD tenant, provided by Omnia Plant
    'clientId': '',
    #This is the API version, the version is included in the URI
    'apiVersion': '',
    #API endpoint to call
    'apiEndpoint': '',
    #Omnia Timeseries API host, will differ depending on being beta or GA release
    'apiHost': ''
}

authority_url = (parameters_file['authorityHostUrl'] + '/' + parameters_file['tenant'])

#uncomment for verbose logging
#turn_on_logging()

### Main logic begins
context = adal.AuthenticationContext(authority_url)
code = context.acquire_user_code(
    parameters_file['resource'],
    parameters_file['clientId']
)
print(code['message'])
token = context.acquire_token_with_device_code(
    parameters_file['resource'],
    code,
    parameters_file['clientId']
)
### Main logic ends

print('Here is the token from "{}":'.format(authority_url))
print(json.dumps(token, indent=2))

api_uri = parameters_file['apiHost'] + '/' + parameters_file['apiEndpoint'] + '/' + parameters_file['apiVersion'] + '/'
api_header = {'Authorization': 'Bearer %s' % token['accessToken']}

def getTimeseriesByName(name):
    parameters = {'name': name}
    r = requests.get(api_uri, params=parameters, headers=api_header)
    print(api_uri)
    print(api_header)
    print("Timeseries metadata by name lookup, with statuscode:", r.status_code, "\nResponse:", 
    json.dumps(r.json(), sort_keys=True, indent=2))

if __name__ == "__main__":
    getTimeseriesByName("<name>")