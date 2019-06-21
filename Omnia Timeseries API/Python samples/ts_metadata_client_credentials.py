import json
import logging
import adal
import requests
from pprint import pprint

def turn_on_logging():
    logging.basicConfig(level=logging.ERROR)

# Below you find client credentials. It is the user responsibility to be compliance to Equinor WR1211 chapter 9.3.1:
# - Passwords used to access Equinor information are private and shall not be shared or handled in a way that it allows 
# unauthorized access. 
# Secure the parameters and credentials, keep them out of the source code and version control. 

parameters_file = {
    #This is the resource id of the Timeseries API, provided by Omnia Plant
    'resource': '', 
    #This is the Equinor Azure AD tenant id, provided by Omnia Plant
    'tenant': '', 
    #This is the authority host where authentication requests are served
    'authorityHostUrl': 'https://login.microsoftonline.com', 
    #This is the client/application id of your client app registered in Equinor's Azure AD tenant, provided by Omnia Plant
    'clientId': '',
    #This is the client/application secret of your client app registered in Equinor's Azure AD tenant, provided by Omnia Plant
    'clientSecret': '',
    #This is the API version, the version is included in the URI
    'apiVersion': '',
    #API endpoint to call
    'apiEndpoint': '',
    #Omnia Timeseries API host, will differ depending on being beta or GA release
    'apiHost': ''
}

authority_url = (parameters_file['authorityHostUrl'] + '/' + parameters_file['tenant'])

turn_on_logging()

context = adal.AuthenticationContext(
    authority_url, validate_authority=True)

token = context.acquire_token_with_client_credentials(
    parameters_file['resource'],
    parameters_file['clientId'],
    parameters_file['clientSecret'])

api_uri = parameters_file['apiHost'] + '/' + parameters_file['apiEndpoint'] + '/' + parameters_file['apiVersion'] + '/'
api_header = {'Authorization': 'Bearer %s' % token['accessToken']}

def getTimeseriesById(id):
    url = api_uri + id
    r = requests.get(url, params=None, headers=api_header)
    print("Timeseries metadata by id lookup, with statuscode:", r.status_code, "\nResponse:", 
    json.dumps(r.json(), sort_keys=True, indent=2))

def getTimeseriesByName(name):
    parameters = {'name': name}
    r = requests.get(api_uri, params=parameters, headers=api_header)
    print("Timeseries metadata by name lookup, with statuscode:", r.status_code, "\nResponse:", 
    json.dumps(r.json(), sort_keys=True, indent=2))

def createTimeseries(body):
    r = requests.post(api_uri, json=body, params=None, headers=api_header)
    print("Created a timeseries metadata object , with statuscode:", r.status_code, "\nResponse:", 
    json.dumps(r.json(), sort_keys=True, indent=2))

def partialUpdateOfTimeseries(id, body):
    url = api_uri + id
    r = requests.patch(url, json=body, params=None, headers=api_header)
    print("Partial update of a timeseries metadata object , with statuscode:", r.status_code, "\nResponse:", 
    json.dumps(r.json(), sort_keys=True, indent=2))

if __name__ == "__main__":
    getTimeseriesById('cb62dda0-a115-4d6a-a69f-2d6785f079e9')
    getTimeseriesByName("50PT1234")
    createTimeseries({
        "name": "23PT1234",
        "description": "Pressure Transmitter",
        "step": True,
        "unit": "bar",
        "assetId": "1218",
        "externalId": "123456-sys"
    })
    partialUpdateOfTimeseries('fa598432-9199-4f4e-8776-8340a3792b0a', {
        "description": "Pressure Transmitter on 1st stage Gas Compressor"
    })
