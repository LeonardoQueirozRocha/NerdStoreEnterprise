using Microsoft.EntityFrameworkCore;
using NSE.Cart.API.Data;
using NSE.Core.Messages.Integrations;
using NSE.MessageBus.Interfaces;

namespace NSE.Cart.API.Services
{
    public class CartIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CartIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribe();
            return Task.CompletedTask;
        }

        private void SetSubscribe()
        {
            _bus.SubscribeAsync<AccomplisheddOrderIntegrationEvent>("AccomplisheddOrder", async request =>
            {
                await EraseCartAsync(request);
            });
        }

        private async Task EraseCartAsync(AccomplisheddOrderIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CartContext>();
            var cart = await context.CustomerCart.FirstOrDefaultAsync(c => c.CustomerId == message.CustomerId);

            if (cart != null)
            {
                context.CustomerCart.Remove(cart);
                await context.SaveChangesAsync();
            }
        }
    }
}
