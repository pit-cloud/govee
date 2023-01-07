using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PowerIT.Govee
{
    public class Account
    {
        private static API _API { get; set; }
        public static bool IsLoggedIn { get; private set; } = false;

        public static bool Login(string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                IsLoggedIn = true;

                _API = new API(apiKey);

                return true;
            }
            else
            {
                throw new Exception("No API key provided.");
            }
        }

        public static Task<bool> LoginAsync(string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                IsLoggedIn = true;

                _API = new API(apiKey);

                return Task.FromResult(true);
            }
            else
            {
                throw new Exception("No API key provided.");
            }
        }

        public static void Logout()
        {
            IsLoggedIn = false;

            _API.Dispose();
        }

        public async static Task LogoutAsync()
        {
            IsLoggedIn = false;

            await Task.Run(() => _API.Dispose());
        }
    }
}
