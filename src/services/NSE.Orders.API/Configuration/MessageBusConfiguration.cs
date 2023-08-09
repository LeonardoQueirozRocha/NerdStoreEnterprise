using NSE.Core.Utils;
using NSE.MessageBus.Extensions;
using NSE.Orders.API.Services;

namespace NSE.Orders.API.Configuration
{
    public static class MessageBusConfiguration
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnectionString("MessageBus"))
                .AddHostedService<OrchestratorOrderIntegrationHandler>();
        }
    }
}
