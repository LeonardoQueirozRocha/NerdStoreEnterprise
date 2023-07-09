using NSE.Core.Data;

namespace NSE.Orders.Domain.Orders.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId);
        void Add(Order order);
        void Update(Order order);

        Task<OrderItem> GetItemByIdAsync(Guid id);
        Task<OrderItem> GetItemByOrderAsync(Guid orderId, Guid productId);

    }
}
