using NSE.Core.Data;

namespace NSE.Payment.API.Models.Interfaces;

public interface IPaymentRepository : IRepository<Payment>
{
    void AddPayment(Payment payment);
    void AddTransaction(Transaction transaction);
    Task<Payment> GetPaymentByOrderId(Guid orderId);
    Task<IEnumerable<Transaction>> GetTransactionsByOrderIdAsync(Guid orderId);
}
