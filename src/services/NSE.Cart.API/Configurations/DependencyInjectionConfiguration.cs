using NSE.Cart.API.Data;
using NSE.WebApi.Core.User;
using NSE.WebApi.Core.User.Interfaces;

namespace NSE.Cart.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<CartContext>();
        }
    }
}
