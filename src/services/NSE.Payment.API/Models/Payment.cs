using NSE.Core.DomainObjects;

namespace NSE.Payment.API.Models
{
    public class Payment : Entity, IAggregateRoot
    {
        public Guid OrderId { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Value { get; set; }
        public CreditCard CreditCard { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Payment()
        {
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
    }
}
