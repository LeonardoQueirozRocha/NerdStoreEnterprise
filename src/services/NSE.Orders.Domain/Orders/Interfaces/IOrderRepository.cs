using NSE.Core.Data;
using System.Data.Common;

namespace NSE.Orders.Domain.Orders.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        DbConnection GetConnection();
        Task<Order> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetListByCustomerIdAsync(Guid customerId);
        void Add(Order order);
        void Update(Order order);
        Task<OrderItem> GetItemByIdAsync(Guid id);
        Task<OrderItem> GetItemByOrderAsync(Guid orderId, Guid productId);
    }
}
