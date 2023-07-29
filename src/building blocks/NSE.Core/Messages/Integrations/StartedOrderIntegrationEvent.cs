namespace NSE.Core.Messages.Integrations
{
    public class StartedOrderIntegrationEvent : IntegrationEvent
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public int PaymentType { get; set; }
        public decimal Value { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpirationDate { get; set; }
        public string CardCvv { get; set; }
    }
}
