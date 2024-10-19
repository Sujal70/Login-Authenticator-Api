using System;
using System.Security.Cryptography;
using System.Text;

namespace ITAM.Application.passwordHash
{
    public class hashPassword
    {
        // Method to convert a password to SHA-256 hashed string
        public static string ComputeHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
