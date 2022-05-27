using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace PowerIT.Govee
{
    public partial class Devices
    {
        public static Models.List.Response List()
        {
            if (Account.IsLoggedIn)
            {
                HttpClient client = API.Client;

                Models.List.Response response = client.GetFromJsonAsync<Models.List.Response>("devices").Result;

                if (response.Status == "Success")
                {
                    return response;
                }
                else
                {
                    throw new Exception("An error has occurred.");
                }
            }
            else
            {
                throw new Exception("Not logged in.");
            }
        }
    }
}
