using NSE.Customers.API.Data;

namespace NSE.Customers.API.Configurations
{
    public static class DependentyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<CustomerContext>();
        }
    }
}
