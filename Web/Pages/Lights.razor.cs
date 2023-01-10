using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using PowerIT.Govee;
using System.Security.Claims;

namespace Web.Pages
{
    public partial class Lights
    {
        private int error = 0;
        private bool loading = false;
        private List<User> users = new();
        private List<Devices> devices = new();

        private class Devices
        {
            public PowerIT.Govee.Models.List.Device? Data { get; set; }
            public PowerIT.Govee.Models.State.Response? State { get; set; }
        }

        private async Task Login(Microsoft.AspNetCore.Components.ChangeEventArgs arguments)
        {
            Error(0);

            if (arguments.Value?.ToString()?.Length > 0)
            {
                try
                {
                    if (Account.IsLoggedIn)
                    {
                        await Account.LogoutAsync();
                    }

                    await Account.LoginAsync(arguments.Value?.ToString());
                    await List();
                }
                catch
                {
                    Error(-1);
                }
            }
        }

        private async Task List()
        {
            Loading();
            Error(0);

            try
            {
                var response = await PowerIT.Govee.Devices.ListAsync();

                if (response.Data.Devices != null)
                {
                    foreach (PowerIT.Govee.Models.List.Device device in response.Data.Devices)
                    {
                        var state = await Device.StateAsync(device.Id, device.Model);

                        devices.Add(new Devices()
                        {
                            Data = device,
                            State = await Device.StateAsync(device.Id, device.Model)
                        });
                    }
                }
                else
                {
                    Error(-3);
                }
            }
            catch
            {
                Error(-1);
            }
        }


        private async Task On(PowerIT.Govee.Models.List.Device device)
        {
            Loading();
            Error(0);

            try
            {
                await Device.OnAsync(device.Id, device.Model);

                Thread.Sleep(1000);

                await List();
            }
            catch
            {
                Error(-2);
            }
        }

        private async Task Off(PowerIT.Govee.Models.List.Device device)
        {
            Loading();
            Error(0);

            try
            {
                await Device.OffAsync(device.Id, device.Model);

                Thread.Sleep(1000);

                await List();
            }
            catch
            {
                Error(-2);
            }
        }

        private void Loading()
        {
            if (loading)
            {
                loading = false;
            }
            else
            {
                loading = true;
            }
        }

        private void Error(int code)
        {
            if (code > -4)
                Loading();

            devices.Clear();

            error = code;

            //-1 = Login error
            //-2 = Action error
            //-3 = No devices
            //-4 = No API keys
            //-5 = API key retrieval error
        }

        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;

            if (user.Identity.IsAuthenticated)
            {
                var sid = new Guid(user.Claims.FirstOrDefault(claim => claim.Type == "sid").Value);

                if (sid != null)
                {
                    using (var db = new UsersContext())
                    {
                        var results = db.Users.Where(u => u.UserId == sid);

                        if (results.Any())
                        {
                            users = await results.ToListAsync();
                        }
                        else
                        {
                            Error(-4);
                        }
                    }
                }
                else
                {
                    Error(-5);
                }
            }
        }
    }
}
