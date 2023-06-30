using NSE.WebApi.Core.User;
using NSE.WebApi.Core.User.Interfaces;

namespace NSE.Bff.Shopping.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
        }
    }
}
