using System;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers
{
    public class PasswordHasher
    {
        public static (string, string) GenerateSecurePassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var securityKey = Convert.ToBase64String(hmac.Key);
                var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return (securityKey, Convert.ToBase64String(hashedPassword));
            }
        }

        public static bool ValidateSecurePassword(string password, string hash, string securityKey)
        {
            using (var hmac = new HMACSHA512(Convert.FromBase64String(securityKey)))
            {
                var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hashBytes = Convert.FromBase64String(hash);

                // Compare the hashed password with the stored hash
                if (hashedPassword.Length != hashBytes.Length)
                    return false;

                for (int i = 0; i < hashedPassword.Length; i++)
                {
                    if (hashedPassword[i] != hashBytes[i])
                        return false;
                }
                return true;
            }
        }
    }
}

