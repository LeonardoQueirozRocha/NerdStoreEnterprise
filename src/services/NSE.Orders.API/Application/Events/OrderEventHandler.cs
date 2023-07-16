using MediatR;
using NSE.Core.Messages.Integrations;
using NSE.MessageBus.Interfaces;

namespace NSE.Orders.API.Application.Events
{
    public class OrderEventHandler : INotificationHandler<AccomplishedOrderEvent>
    {
        private readonly IMessageBus _bus;

        public OrderEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(AccomplishedOrderEvent message, CancellationToken cancellationToken)
        {
            await _bus.PublishAsync(new AccomplisheddOrderIntegrationEvent(message.CustomerId));
        }
    }
}
