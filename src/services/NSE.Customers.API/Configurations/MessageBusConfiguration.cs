using NSE.Core.Utils;
using NSE.Customers.API.Services;
using NSE.MessageBus.Extensions;

namespace NSE.Customers.API.Configurations
{
    public static class MessageBusConfiguration
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnectionString("MessageBus"))
                    .AddHostedService<CustomerRegisterIntegrationHandler>();
        }
    }
}
