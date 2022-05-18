using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PowerIT.Govee
{
    public partial class Device
    {
        public static async Task<Models.Control.Response> On(string deviceId, string model)
        {
            if (Account.IsLoggedIn)
            {
                if (string.IsNullOrEmpty(deviceId))
                    throw new Exception("No device ID provided.");

                if (string.IsNullOrEmpty(model))
                    throw new Exception("No model provided.");

                HttpClient client = API.Client;

                Models.Control.Request request = new Models.Control.Request
                {
                    Id = deviceId,
                    Model = model,
                    Command = new Models.Control.Command
                    {
                        Name = Models.Control.Commands.Turn,
                        Value = "on"
                    }
                };

                JsonSerializerOptions serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                string jsonString = JsonSerializer.Serialize(request, serializeOptions);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("devices/control", content);

                if (response.IsSuccessStatusCode)
                {
                    return new Models.Control.Response
                    {
                        Code = (int)response.StatusCode,
                        Status = response.ReasonPhrase
                    };
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

        public static async Task<Models.Control.Response> Off(string deviceId, string model)
        {
            if (Account.IsLoggedIn)
            {
                if (string.IsNullOrEmpty(deviceId))
                    throw new Exception("No device ID provided.");

                if (string.IsNullOrEmpty(model))
                    throw new Exception("No model provided.");

                HttpClient client = API.Client;

                Models.Control.Request request = new Models.Control.Request
                {
                    Id = deviceId,
                    Model = model,
                    Command = new Models.Control.Command
                    {
                        Name = Models.Control.Commands.Turn,
                        Value = "off"
                    }
                };

                JsonSerializerOptions serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                string jsonString = JsonSerializer.Serialize(request, serializeOptions);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("devices/control", content);

                if (response.IsSuccessStatusCode)
                {
                    return new Models.Control.Response
                    {
                        Code = (int)response.StatusCode,
                        Status = response.ReasonPhrase
                    };
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

        public static async Task<Models.Control.Response> Brightness(string deviceId, string model, int brightness)
        {
            if (Account.IsLoggedIn)
            {
                if (string.IsNullOrEmpty(deviceId))
                    throw new Exception("No device ID provided.");

                if (string.IsNullOrEmpty(model))
                    throw new Exception("No model provided.");

                if (brightness > 100 || brightness < 0)
                    throw new Exception("Invaild brightness value provided.");

                HttpClient client = API.Client;

                Models.Control.Request request = new Models.Control.Request
                {
                    Id = deviceId,
                    Model = model,
                    Command = new Models.Control.Command
                    {
                        Name = Models.Control.Commands.Brightness,
                        Value = brightness
                    }
                };

                JsonSerializerOptions serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                string jsonString = JsonSerializer.Serialize(request, serializeOptions);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("devices/control", content);

                if (response.IsSuccessStatusCode)
                {
                    return new Models.Control.Response
                    {
                        Code = (int)response.StatusCode,
                        Status = response.ReasonPhrase
                    };
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


        public static async Task<Models.Control.Response> Temprature(string deviceId, string model, int temprature)
        {
            if (Account.IsLoggedIn)
            {
                if (string.IsNullOrEmpty(deviceId))
                    throw new Exception("No device ID provided.");

                if (string.IsNullOrEmpty(model))
                    throw new Exception("No model provided.");

                if (temprature > 9000 || temprature < 2000)
                    throw new Exception("Invaild temprature value provided.");

                HttpClient client = API.Client;

                Models.Control.Request request = new Models.Control.Request
                {
                    Id = deviceId,
                    Model = model,
                    Command = new Models.Control.Command
                    {
                        Name = Models.Control.Commands.Temprature,
                        Value = temprature
                    }
                };

                JsonSerializerOptions serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                string jsonString = JsonSerializer.Serialize(request, serializeOptions);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("devices/control", content);

                if (response.IsSuccessStatusCode)
                {
                    return new Models.Control.Response
                    {
                        Code = (int)response.StatusCode,
                        Status = response.ReasonPhrase
                    };
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

        public static async Task<Models.Control.Response> Color(string deviceId, string model, Color color)
        {
            if (Account.IsLoggedIn)
            {
                if (string.IsNullOrEmpty(deviceId))
                    throw new Exception("No device ID provided.");

                if (string.IsNullOrEmpty(model))
                    throw new Exception("No model provided.");

                if (color.IsEmpty)
                    throw new Exception("No colour provided.");

                HttpClient client = API.Client;

                Models.Control.Request request = new Models.Control.Request
                {
                    Id = deviceId,
                    Model = model,
                    Command = new Models.Control.Command
                    {
                        Name = Models.Control.Commands.Color,
                        Value = new Models.Control.Color
                        {
                            Red = color.R,
                            Green = color.G,
                            Blue = color.B
                        }
                    }
                };

                JsonSerializerOptions serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                string jsonString = JsonSerializer.Serialize(request, serializeOptions);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("devices/control", content);

                if (response.IsSuccessStatusCode)
                {
                    return new Models.Control.Response
                    {
                        Code = (int)response.StatusCode,
                        Status = response.ReasonPhrase
                    };
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