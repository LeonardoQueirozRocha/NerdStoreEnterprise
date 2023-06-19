using Microsoft.Extensions.DependencyInjection;
using NSE.MessageBus.Interfaces;

namespace NSE.MessageBus.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException(nameof(connection));

            services.AddSingleton<IMessageBus>(new MessageBus(connection));

            return services;
        }
    }
}
