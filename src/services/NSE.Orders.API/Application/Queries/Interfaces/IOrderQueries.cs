using NSE.Orders.API.Application.DTOs;

namespace NSE.Orders.API.Application.Queries.Interfaces
{
    public interface IOrderQueries
    {
        Task<OrderDTO> GetLastOrderAsync(Guid customerId);
        Task<IEnumerable<OrderDTO>> GetListByCustomerIdAsync(Guid customerId);
        Task<OrderDTO> GetAuthorizedOrdersAsync();
    }
}