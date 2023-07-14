using NSE.Core.Messages;

namespace NSE.Orders.API.Application.Events
{
    public class AccomplishedOrderEvent : Event
    {
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }

        public AccomplishedOrderEvent(Guid orderId, Guid customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
    }
}
