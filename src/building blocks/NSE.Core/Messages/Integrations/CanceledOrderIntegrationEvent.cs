namespace NSE.Core.Messages.Integrations;

public class CanceledOrderIntegrationEvent : IntegrationEvent
{
    public Guid CustomerId { get; private set; }
    public Guid OrderId { get; private set; }

    public CanceledOrderIntegrationEvent(Guid customerId, Guid orderId)
    {
        CustomerId = customerId;
        OrderId = orderId;
    }
}
