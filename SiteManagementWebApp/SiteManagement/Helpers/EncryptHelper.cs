using System.Text;
using System;
using System.Security.Cryptography;

namespace SiteManagement.Helpers
{
    public static class EncryptHelper
    {

       public static string SHA256Hash(string password)
        {
            string source = password;
            using (SHA256 sha1Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return (hash);
            }
        }

    }
}
