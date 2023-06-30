using Microsoft.AspNetCore.Mvc.DataAnnotations;
using NSE.WebApi.Core.User;
using NSE.WebApi.Core.User.Interfaces;
using NSE.WebApp.MVC.Extensions.CustomDataAnnotations.CpfAnnotation;

namespace NSE.WebApp.MVC.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddHttpServices();
        }
    }
}
