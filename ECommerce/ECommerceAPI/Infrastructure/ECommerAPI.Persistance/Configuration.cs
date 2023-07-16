using Microsoft.Extensions.Configuration;

namespace ECommerAPI.Persistance
{
    static class Configuration
    {
       static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceAPI.API/"));
                //SethBasePath CM'ın hangi dosya üzerinde arama yapacağını söylüyoruz. Temel dizini ayarlıyoruz.
                //PathCombine(Directory.GetCurrentDirectory = Şuan mevcut dizinden başla virgülden sornaki dosya dizinine doğru ulaş demek istedik. Çünkü appsettings.json dosyamız Presentation katmanının içerisinde.   .. mevcut dizinden bir geri gel anlamında cd .. gibi. Şuan bulunduğumuz klasör Infrastrucure klasöründeki Persisttence klasörü)
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
