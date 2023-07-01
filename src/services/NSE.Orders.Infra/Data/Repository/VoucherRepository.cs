using NSE.Core.Data;
using NSE.Orders.Domain.Vouchers;

namespace NSE.Orders.Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly OrdersContext _context;

        public VoucherRepository(OrdersContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose() => _context.Dispose();
    }
}
