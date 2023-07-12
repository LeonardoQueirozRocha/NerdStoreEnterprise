using NSE.Orders.Domain.Orders;

namespace NSE.Orders.API.Application.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }
        public string VoucherCode { get; set; }
        public bool UsedVoucher { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
        public AddressDTO Address { get; set; }

        public static OrderDTO ForOrderDTO(Order order)
        {
            var orderDTO = new OrderDTO()
            {
                Id = order.Id,
                Code = order.Code,
                Status = (int)order.OrderStatus,
                Date = order.CreationDate,
                TotalValue = order.TotalValue,
                Discount = order.Discount,
                UsedVoucher = order.UsedVoucher,
                OrderItems = new List<OrderItemDTO>(),
                Address = new AddressDTO()
            };

            foreach (var item in order.OrderItems)
            {
                orderDTO.OrderItems.Add(new OrderItemDTO
                {
                    Name = item.ProductName,
                    Image = item.ProductImage,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId,
                    Value = item.UnitValue,
                    OrderId = item.OrderId
                });
            }

            orderDTO.Address = new AddressDTO()
            {
                PublicPlace = order.Address.PublicPlace,
                Number = order.Address.Number,
                Complement = order.Address.Complement,
                Neighborhood = order.Address.Neighborhood,
                ZipCode = order.Address.ZipCode,
                City = order.Address.City,
                State = order.Address.State
            };

            return orderDTO;
        }
    }
}
