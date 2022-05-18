using System;
using System.Net.Http;

namespace PowerIT.Govee
{
    public class API
    {
        public static HttpClient Client = new HttpClient();

        public API(string apiKey)
        {
            Client.BaseAddress = new Uri("https://developer-api.govee.com/v1/");

            Client.DefaultRequestHeaders.Add("Govee-API-Key", apiKey);
        }
    }
}
