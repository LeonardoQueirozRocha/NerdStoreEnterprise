using NSE.Core.Mediator;

namespace NSE.Orders.API.Configuration
{
    public static class DependentyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }
    }
}
