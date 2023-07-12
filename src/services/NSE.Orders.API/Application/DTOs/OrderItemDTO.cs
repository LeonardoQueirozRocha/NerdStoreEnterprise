using NSE.Orders.Domain.Orders;

namespace NSE.Orders.API.Application.DTOs
{
    public class OrderItemDTO
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

        public static OrderItem ForOrderItem(OrderItemDTO orderItemDTO)
        {
            return new OrderItem(
                orderItemDTO.ProductId,
                orderItemDTO.Name,
                orderItemDTO.Quantity,
                orderItemDTO.Value,
                orderItemDTO.Image);
        }
    }
}