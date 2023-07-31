using NSE.Core.Data;

namespace NSE.Payment.API.Models.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        void AddPayment(Payment payment);
    }
}
