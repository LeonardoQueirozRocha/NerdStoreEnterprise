using NSE.Payment.API.Data;
using NSE.Payment.API.Data.Repositories;
using NSE.Payment.API.Facade;
using NSE.Payment.API.Facade.Interfaces;
using NSE.Payment.API.Models.Interfaces;
using NSE.Payment.API.Services;
using NSE.Payment.API.Services.Interfaces;
using NSE.WebApi.Core.User;
using NSE.WebApi.Core.User.Interfaces;

namespace NSE.Payment.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentFacade, CreditCardPaymentFacade>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<PaymentContext>();
        }
    }
}
