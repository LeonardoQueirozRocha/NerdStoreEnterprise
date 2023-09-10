using NSE.Bff.Shopping.Extensions.Handlers;
using NSE.Bff.Shopping.Services;
using NSE.Bff.Shopping.Services.Interfaces;
using NSE.WebApi.Core.Extensions;

namespace NSE.Bff.Shopping.Configurations;

public static class HttpServicesConfiguration
{
    public static void AddHttpServices(this IServiceCollection services)
    {
        services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

        services.AddHttpClient<ICatalogService, CatalogService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPollyPolicy()
                .AllowSelfSignedCertificate();

        services.AddHttpClient<ICartService, CartService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPollyPolicy()
                .AllowSelfSignedCertificate();

        services.AddHttpClient<IOrderService, OrderService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPollyPolicy()
                .AllowSelfSignedCertificate();

        services.AddHttpClient<ICustomerService, CustomerService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPollyPolicy()
                .AllowSelfSignedCertificate();
    }
}
