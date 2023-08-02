using NSE.Core.Utils;
using NSE.MessageBus.Extensions;
using NSE.Payment.API.Services;

namespace NSE.Payment.API.Configurations
{
    public static class MessageBusConfiguration
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnectionString("MessageBus"))
                    .AddHostedService<PaymentIntegrationHandler>();
        }
    }
}
