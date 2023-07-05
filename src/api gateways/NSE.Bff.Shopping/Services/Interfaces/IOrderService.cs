using NSE.Bff.Shopping.Models;

namespace NSE.Bff.Shopping.Services.Interfaces
{
    public interface IOrderService
    {
        Task<VoucherDTO> GetVoucherByCodeAsync(string code);
    }
}
