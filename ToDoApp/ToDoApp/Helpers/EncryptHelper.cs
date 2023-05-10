using System.Security.Cryptography;
using System.Text;

namespace ToDoApp.Helpers
{
    public static class EncryptHelper
    {
        public static string SHA1Encrypt(string text)
        {
            string source = text;
            using (SHA1 sha1Hash = SHA1.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash;
            }
        }
    }
}
