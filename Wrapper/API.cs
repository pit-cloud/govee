using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PowerIT.Govee
{
    public class API
    {
        public static HttpClient Client;

        public API(string apiKey)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://developer-api.govee.com/v1/");

            Client.DefaultRequestHeaders.Add("Govee-API-Key", apiKey);
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
