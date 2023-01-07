using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using PowerIT.Govee;

namespace CSharpCOD
{
    class Program
    {
        static async Task Main(string[] arguments)
        {
            Account.Login("1aaebbb1-2e82-42cc-a415-2db1a8a8b256");

            if (Account.IsLoggedIn)
            {
                //List devices
                var devices = await Devices.ListAsync();
                var device = devices.Data.Devices.First(d => d.Name == "Lounge Light 2");

                //Device state
                var state = await Device.StateAsync(device.Id, device.Model);
                Console.WriteLine(state.Data.Properties.First(p => p.Online != null).Online.ToString().ToLower());

                ////Turn off device
                //var off = await Device.OffAsync(device.Id, device.Model);
                //Console.WriteLine(off.Status);

                ////Turn on device
                //var on = await Device.OnAsync(device.Id, device.Model);
                //Console.WriteLine(on.Status);

                ////Change device brightness
                //var brightness = await Device.BrightnessAsync(device.Id, device.Model, 100);
                //Console.WriteLine(brightness.Status);

                //////Change device color
                //var color = await Device.ColorAsync(device.Id, device.Model, Color.White);
                //Console.WriteLine(color.Status);

                ////Change device temprature
                //var temprature = await Device.TempratureAsync(device.Id, device.Model, 9000);
                //Console.WriteLine(temprature.Status);
            }
            else
            {
                Console.Write("Not logged in.");
            }
        }
    }
}
