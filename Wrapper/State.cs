using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace PowerIT.Govee
{
    public partial class Device
    {
        public static async Task<Models.State.Response> State(string deviceId, string model)
        {
            if (Account.IsLoggedIn)
            {
                if (string.IsNullOrEmpty(deviceId))
                    throw new Exception("No device ID provided.");

                if (string.IsNullOrEmpty(model))
                    throw new Exception("No model provided.");

                HttpClient client = API.Client;

                Models.State.Response response = await client.GetFromJsonAsync<Models.State.Response>(string.Format("devices/state?device={0}&model={1}", HttpUtility.UrlEncode(deviceId), model));

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
