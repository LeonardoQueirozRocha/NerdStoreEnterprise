﻿using Microsoft.AspNetCore.Mvc.DataAnnotations;
using NSE.WebApi.Core.User;
using NSE.WebApi.Core.User.Interfaces;
using NSE.WebApp.MVC.Extensions.CustomDataAnnotations.CpfAnnotation;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using NSE.WebApp.MVC.Services.Interfaces;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace NSE.WebApp.MVC.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAuthService, AuthService>();

            services.AddHttpClient<ICatalogService, CatalogService>()
                    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                    //.AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));
                    .AddPolicyHandler(PollyExtensions.RetryWait())
                    .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAspNetUser, AspNetUser>();
        }
    }

    public class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> RetryWait()
        {
            var retry = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                }, (outcome, timespan, retryCount, context) =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Tentando pela {retryCount} vez!");
                    Console.ForegroundColor = ConsoleColor.White;
                });

            return retry;
        }
    }
}
