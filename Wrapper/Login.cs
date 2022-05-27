using System;
using System.Threading.Tasks;

namespace PowerIT.Govee
{
    public class Account
    {
        public static bool IsLoggedIn { get; set; } = false;

        public static bool Login(string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                IsLoggedIn = true;

                new API(apiKey);

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

                new API(apiKey);

                return Task.FromResult(true);
            }
            else
            {
                throw new Exception("No API key provided.");
            }
        }
    }
}
