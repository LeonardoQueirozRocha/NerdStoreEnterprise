namespace NSE.Core.Messages.Integrations;

public class OrderWrittenOffFromStockIntegrationEvent : IntegrationEvent
{
    public Guid CustomerId { get; private set; }
    public Guid OrderId { get; private set; }

    public OrderWrittenOffFromStockIntegrationEvent(Guid customerId, Guid orderId)
    {
        CustomerId = customerId;
        OrderId = orderId;
    }
}
