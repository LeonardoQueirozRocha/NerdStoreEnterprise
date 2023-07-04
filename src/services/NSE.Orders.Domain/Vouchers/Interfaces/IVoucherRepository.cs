using NSE.Core.Data;

namespace NSE.Orders.Domain.Vouchers.Interfaces
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<Voucher> GetVoucherbyCodeAsync(string code);
    }
}
