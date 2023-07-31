using NSE.Core.Data;
using NSE.Payment.API.Models.Interfaces;

namespace NSE.Payment.API.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void AddPayment(Models.Payment payment)
        {
            _context.Payments.Add(payment);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
