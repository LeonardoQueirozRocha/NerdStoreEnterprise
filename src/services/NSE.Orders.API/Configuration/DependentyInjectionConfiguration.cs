using FluentValidation.Results;
using MediatR;
using NSE.Core.Mediator;
using NSE.Orders.API.Application.Commands;
using NSE.Orders.API.Application.Events;
using NSE.Orders.API.Application.Queries;
using NSE.Orders.API.Application.Queries.Interfaces;
using NSE.Orders.Domain.Orders.Interfaces;
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
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Commands
            services.AddScoped<IRequestHandler<AddOrderCommand, ValidationResult>, OrderCommandHandler>();

            // Events
            services.AddScoped<INotificationHandler<AccomplishedOrderEvent>, OrderEventHandler>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();
            services.AddScoped<IOrderQueries, OrderQueries>();

            // Data
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<OrdersContext>();
        }
    }
}
