using NSE.Catalog.API.Data;
using NSE.Catalog.API.Data.Repositories;
using NSE.Catalog.API.Data.Repositories.Interfaces;

namespace NSE.Catalog.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<CatalogContext>();
        }
    }
}
