using NSE.Bff.Shopping.Models;
using NSE.Core.Communication;

namespace NSE.Bff.Shopping.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseResult> ConcludeOrderAsync(OrderDTO order);
        Task<OrderDTO> GetLastOrderAsync();
        Task<IEnumerable<OrderDTO>> GetListByCustomerIdAsync();
        Task<VoucherDTO> GetVoucherByCodeAsync(string code);
    }
}
