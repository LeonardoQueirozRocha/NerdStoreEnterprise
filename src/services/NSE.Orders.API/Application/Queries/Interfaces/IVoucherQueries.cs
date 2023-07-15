using NSE.Orders.API.Application.DTOs;

namespace NSE.Orders.API.Application.Queries.Interfaces
{
    public interface IVoucherQueries
    {
        Task<VoucherDTO> GetVoucherByCodeAsync(string code);
    }
}
