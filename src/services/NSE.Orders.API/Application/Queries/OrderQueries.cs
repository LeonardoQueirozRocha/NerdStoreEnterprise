using Dapper;
using NSE.Orders.API.Application.DTOs;
using NSE.Orders.API.Application.Queries.Interfaces;
using NSE.Orders.Domain.Orders.Interfaces;

namespace NSE.Orders.API.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQueries(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDTO> GetLastOrderAsync(Guid customerId)
        {
            var order = await _orderRepository
                .GetConnection()
                    .QueryAsync<dynamic>(SqlQueries.SELECT_LAST_ORDER, new { customerId });

            return OrderMap(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetListByCustomerIdAsync(Guid customerId)
        {
            var orders = await _orderRepository.GetListByCustomerIdAsync(customerId);

            return orders.Select(OrderDTO.ForOrderDTO);
        }

        private static OrderDTO OrderMap(dynamic result)
        {
            var order = new OrderDTO
            {
                Code = result[0].Code,
                Status = result[0].OrderStatus,
                TotalValue = result[0].TotalValue,
                Discount = result[0].Discount,
                UsedVoucher = result[0].UsedVoucher,
                OrderItems = new List<OrderItemDTO>(),
                Address = new AddressDTO
                {
                    PublicPlace = result[0].PublicPlace,
                    Neighborhood = result[0].Neighborhood,
                    ZipCode = result[0].ZipCode,
                    City = result[0].City,
                    Complement = result[0].Complement,
                    State = result[0].State,
                    Number = result[0].Number,
                }
            };

            foreach (var item in result)
            {
                var orderItem = new OrderItemDTO
                {
                    Name = item.Name,
                    Value = item.UnitValue,
                    Quantity = item.Quantity,
                    Image = item.ProductImage
                };

                order.OrderItems.Add(orderItem);
            }

            return order;
        }
    }
}
