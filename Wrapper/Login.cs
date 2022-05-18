using System;

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
    }
}
