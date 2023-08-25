using NSE.Bff.Shopping.Services.gRPC;
using NSE.Bff.Shopping.Services.Interfaces.gRPC;
using NSE.Cart.API.Services.gRPC;

namespace NSE.Bff.Shopping.Configurations;

public static class GrpcServicesConfiguration
{
    public static void AddGrpcServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<GrpcServiceInterceptor>();
        services.AddScoped<ICartGrpcService, CartGrpcService>();
        services.AddGrpcClient<ShoppingCart.ShoppingCartClient>(o => o.Address = new Uri(configuration["CartUrl"]))
                .AddInterceptor<GrpcServiceInterceptor>();
    }
}
