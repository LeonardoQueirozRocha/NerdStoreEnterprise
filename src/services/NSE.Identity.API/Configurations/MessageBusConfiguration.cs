﻿using NSE.Core.Utils;
using NSE.MessageBus.Extensions;

namespace NSE.Identity.API.Configurations
{
    public static class MessageBusConfiguration
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnectionString("MessageBus"));
        }
    }
}
