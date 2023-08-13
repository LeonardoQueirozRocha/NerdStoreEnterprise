using NSE.Core.DomainObjects;
using NSE.Core.Messages.Integrations;
using NSE.MessageBus.Interfaces;
using NSE.Orders.Domain.Orders.Interfaces;

namespace NSE.Orders.API.Services
{
    public class OrderIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public OrderIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetSubscribers()
        {
            _bus.SubscribeAsync<CanceledOrderIntegrationEvent>("CanceledOrder", async request =>
            {
                await CancelOrder(request);
            });

            _bus.SubscribeAsync<PaidOrderIntegrationEvent>("PaidOrder", async request =>
            {
                await ConcludeOrder(request);
            });
        }

        private async Task ConcludeOrder(PaidOrderIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();
            var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
            var order = await orderRepository.GetByIdAsync(message.OrderId);
            order.ConcludeOrder();
            orderRepository.Update(order);

            if (!await orderRepository.UnitOfWork.Commit())
                throw new DomainException($"Problemas ao finalizar o pedido {message.OrderId}");
        }

        private async Task CancelOrder(CanceledOrderIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();
            var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
            var order = await orderRepository.GetByIdAsync(message.OrderId);
            order.CancelOrder();
            orderRepository.Update(order);

            if (!await orderRepository.UnitOfWork.Commit())
                throw new DomainException($"Problemas ao finalizar o pedido {message.OrderId}");
        }
    }
}
