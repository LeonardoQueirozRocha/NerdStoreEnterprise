using FluentValidation.Results;
using MediatR;
using NSE.Core.Mediator;
using NSE.Customers.API.Application.Commands;
using NSE.Customers.API.Application.Events;
using NSE.Customers.API.Data;
using NSE.Customers.API.Data.Repositories;
using NSE.Customers.API.Models.Interfaces;
using NSE.Customers.API.Services;

namespace NSE.Customers.API.Configurations
{
    public static class DependentyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<CustomerRegisterCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<RegisteredCustomerEvent>, CustomerEventHandler>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<CustomerContext>();
            services.AddHostedService<CustomerRegisterIntegrationHandler>();
        }
    }
}
