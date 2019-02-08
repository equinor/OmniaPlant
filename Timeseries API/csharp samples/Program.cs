using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http;
using System.Web;

namespace HelloTimeseries
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                callTimeseriesAPI().Wait();
            }
            catch (Exception)
            {

                throw;
            }


        }

       static private async Task callTimeseriesAPI ()
        {
            /*
            * NuGet Packages:
            * Microsoft.IdentityModel.Clients.ActiveDirectory
            * 
            * Below you find client credentials. It is the user responsibility to be compliance to Equinor WR1211 chapter 9.3.1:
            * Passwords used to access Equinor information are private and shall not be shared or handled in a way that it allows 
            * unauthorized access. 
            * Secure the parameters and credentials, keep them out of the source code and version control. 
            */

            //This is the resource id of the Timeseries API, provided by Omnia Plant
            const string resourceId = "";

            //This is the Equinor Azure AD tenant id, provided by Omnia Plant
            const string tenant = "";

            //This is the authority host where authentication requests are served
            const string authorityHostUrl = "";

            //This is the client/application id of your client app registered in Equinor's Azure AD tenant, provided by Omnia Plant
            const string clientId = "";

            //This is the client/application secret of your client app registered in Equinor's Azure AD tenant, provided by Omnia Plant
            const string clientSecret = "";

            //This is the API version, the version is included in the URI
            const string apiVersion = "v1.0";

            //API endpoint to call
            const string apiEndpoint = "timeseries";

            //Omnia Timeseries API host, will differ depending on being beta or GA release
            const string apiHost = "https://host/timeseries";

            // Get Access Token
            var authenticationContext = new AuthenticationContext(
               $"{authorityHostUrl}/{tenant}",
               TokenCache.DefaultShared);

            AuthenticationResult token = await authenticationContext.AcquireTokenAsync(
                          resource: resourceId,
                          clientCredential: new ClientCredential(
                              clientId: clientId,
                              clientSecret: clientSecret));
            string bearerToken = "Bearer " + token.AccessToken;

            // Get Timeseries Metadata object by ID
            var client = new HttpClient();
           
            // Request headers
            client.DefaultRequestHeaders.Add("Authorization", bearerToken);

            // ID of the Timeseries Metadata object to get
            string id = "guid";

            var myUri = $"{apiHost}/{apiVersion}/{apiEndpoint}/{id}";
            var response = await client.GetAsync(myUri);

            string json = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(json);

        }
    }
}
