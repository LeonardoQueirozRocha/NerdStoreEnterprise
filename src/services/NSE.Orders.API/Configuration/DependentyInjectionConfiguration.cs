using NSE.Core.Mediator;
using NSE.Orders.API.Application.Queries;
using NSE.Orders.API.Application.Queries.Interfaces;
using NSE.Orders.Domain.Vouchers.Interfaces;
using NSE.Orders.Infra.Data;
using NSE.Orders.Infra.Data.Repository;
using NSE.WebApi.Core.User;
using NSE.WebApi.Core.User.Interfaces;

namespace NSE.Orders.API.Configuration
{
    public static class DependentyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQuery, VoucherQuery>();

            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<OrdersContext>();
        }
    }
}
