using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace timeseries_msal_devicecode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string tenant = "3aa4a235-b6e2-48d5-9195-7fcf05b459b0";
            const string resource = "32f2a909-8a98-4eb8-b22d-1208d9350cb0";
            const string clientId = "b5e79b0d-fddb-4f65-8d10-99863858779f";
            //var authority = new Uri($"https://login.windows.net/{tenant}");
            string redirectUri = "https://login.microsoftonline.com/common/oauth2/nativeclient";
            string[] scopes = new string[] { $"{resource}/.default" };

            try
            {

                var app = PublicClientApplicationBuilder.Create(clientId)
                    .WithTenantId(tenant)
                    .WithExtraQueryParameters($"resource={resource}")
                    .WithRedirectUri(redirectUri)
                    .Build();

                AuthenticationResult result = null;
                var accounts = await app.GetAccountsAsync();
                try
                {
                    result = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                        //.WithClaims("Timeseries.Admin,Timeseries.Read,Timeseries.Read.All")
                        .ExecuteAsync();

                }
                catch (MsalUiRequiredException)
                {
                    var customWebUi = new CustomWebUi();
                    result = await app.AcquireTokenWithDeviceCode(scopes,
                        async (dc) =>
                        {
                            Console.WriteLine($"Enter the following device code on the web page: {dc.UserCode}");
                            OpenBrowser(dc.VerificationUrl);
                        })
                        .ExecuteAsync();
                }

                if (result != null)
                {
                    var httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://api.gateway.equinor.com/");
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", result.AccessToken);
                    Console.WriteLine("Requesting timeseries...");
                    var response = await httpClient.GetAsync("/plant-beta/timeseries/v1.2?limit=10");
                    Console.WriteLine("Reading response body...");
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{ex.GetType().Name}] {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }

        private class CustomWebUi : ICustomWebUi
        {
            public CustomWebUi()
            {
            }

            public Task<Uri> AcquireAuthorizationCodeAsync(Uri authorizationUri, Uri redirectUri, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }

        private static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(new ProcessStartInfo(url) { CreateNoWindow = true, UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
