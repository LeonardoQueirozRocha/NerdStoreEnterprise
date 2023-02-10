using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAuthService, AuthService>();

            return services;
        }
    }
}
