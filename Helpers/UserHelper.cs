using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailVerificationApp.Helpers
{
    public class UserHelper
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();

        public static void RegisterUser(string email, string password)
        {
            if (!users.ContainsKey(email))
            {
                users[email] = password;
            }
        }

        public static bool ValidateUser(string email, string password)
        {
            return users.ContainsKey(email) && users[email] == password;
        }
    }
}