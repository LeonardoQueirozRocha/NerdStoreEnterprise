using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Orders.Domain.Vouchers;
using NSE.Orders.Domain.Vouchers.Interfaces;

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

        public async Task<Voucher> GetVoucherbyCodeAsync(string code)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(p => p.Code == code);
        }

        public void Dispose() => _context.Dispose();
    }
}