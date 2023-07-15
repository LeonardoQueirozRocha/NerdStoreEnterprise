using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Orders.Domain.Orders;
using NSE.Orders.Domain.Orders.Interfaces;
using System.Data.Common;

namespace NSE.Orders.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersContext _context;

        public OrderRepository(OrdersContext ordersContext)
        {
            _context = ordersContext;
        }

        public IUnitOfWork UnitOfWork => _context;

        public DbConnection GetConnection() => _context.Database.GetDbConnection();

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetListByCustomerIdAsync(Guid customerId)
        {
            return await _context.Orders
                .Include(p => p.OrderItems)
                .AsNoTracking()
                .Where(p => p.CustomerId == customerId)
                .ToListAsync();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public async Task<OrderItem> GetItemByIdAsync(Guid id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task<OrderItem> GetItemByOrderAsync(Guid orderId, Guid productId)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(p => p.ProductId == productId && p.OrderId == orderId);
        }

        public void Dispose() => _context.Dispose();
    }
}
