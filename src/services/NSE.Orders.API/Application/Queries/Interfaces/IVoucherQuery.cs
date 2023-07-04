using NSE.Orders.API.Application.DTOs;

namespace NSE.Orders.API.Application.Queries.Interfaces
{
    public interface IVoucherQuery
    {
        Task<VoucherDTO> GetVoucherByCodeAsync(string code);
    }
}
