using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using RestSharp;

namespace ApiClientRestSharp.Utils
{
    public static class Rest
    {
        public static string baseUrl = "https://localhost:7225/api/v1/commands";

        public static async void SendRequest(RestSharp.Method method, string? argument = "", object? data = null)
        {
            //Disable ssl certificate verfication
            var options = new RestClientOptions(baseUrl) {
            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };

            RestClient client = new RestClient(options);
            RestRequest request = new RestRequest(argument, method);
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-Api-Key", "mySecretApiKey!");

            if (data != null)
            {
                request.AddJsonBody(data);
            }

            try
            {
                RestResponse response = await client.ExecuteAsync(request);
                System.Console.WriteLine("\nReturned status: " + response.StatusCode);
                if(response.Content != null){
                    System.Console.WriteLine(response.Content);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

        }
    }
}

