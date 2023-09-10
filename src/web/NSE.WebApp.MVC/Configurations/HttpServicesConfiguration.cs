using NSE.WebApi.Core.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Configurations;

public static class HttpServicesConfiguration
{
    public static void AddHttpServices(this IServiceCollection services)
    {
        services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<IAuthService, AuthService>()
                .AddPollyPolicy()
                .AllowSelfSignedCertificate();

        services.AddHttpClient<ICatalogService, CatalogService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPollyPolicy()
                .AllowSelfSignedCertificate();

        services.AddHttpClient<IShoppingBffService, ShoppingBffService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPollyPolicy()
                .AllowSelfSignedCertificate();

        services.AddHttpClient<ICustomerService, CustomerService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPollyPolicy()
                .AllowSelfSignedCertificate();
    }
}