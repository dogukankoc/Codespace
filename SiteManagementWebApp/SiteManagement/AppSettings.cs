using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

namespace SiteManagement
{
    public class AppSettings
    {
        private static string _connectionString;
        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
    }
}
