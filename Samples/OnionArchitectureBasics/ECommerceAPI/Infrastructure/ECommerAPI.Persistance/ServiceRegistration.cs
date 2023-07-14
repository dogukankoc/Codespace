using ECommerAPI.Persistance.Concretes;
using ECommerceAPI.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services) 
        {
            services.AddSingleton<IProductService, ProductService>(); 
        }
    }
}
