﻿using FluentValidation.Results;
using MediatR;
using NSE.Core.Mediator;
using NSE.Customers.API.Application.Commands;
using NSE.Customers.API.Data;

namespace NSE.Customers.API.Configurations
{
    public static class DependentyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<CustomerRegisterCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<CustomerContext>();
        }
    }
}