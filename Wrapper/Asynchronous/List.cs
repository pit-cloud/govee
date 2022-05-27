using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PowerIT.Govee
{
    public partial class Devices
    {
        public static async Task<Models.List.Response> ListAsync()
        {
            if (Account.IsLoggedIn)
            {
                HttpClient client = API.Client;

                Models.List.Response response = await client.GetFromJsonAsync<Models.List.Response>("devices");

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
