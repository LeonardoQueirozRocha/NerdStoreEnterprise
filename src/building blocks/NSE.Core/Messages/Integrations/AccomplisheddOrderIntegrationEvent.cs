namespace NSE.Core.Messages.Integrations
{
    public class AccomplisheddOrderIntegrationEvent : IntegrationEvent
    {
        public Guid CustomerId { get; private set; }

        public AccomplisheddOrderIntegrationEvent(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
