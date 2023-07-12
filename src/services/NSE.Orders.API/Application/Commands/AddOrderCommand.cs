using NSE.Core.Messages;
using NSE.Orders.API.Application.DTOs;

namespace NSE.Orders.API.Application.Commands
{
    public class AddOrderCommand : Command
    {
        // Order
        public Guid CustomerId { get; set; }
        public decimal TotalValue { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }

        // Voucher
        public string VoucherCode { get; set; }
        public bool UsedVoucher { get; set; }
        public decimal Discount { get; set; }

        // Address
        public AddressDTO Address { get; set; }

        // Card
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string Cardexpiration { get; set; }
        public string CardCvv { get; set; }
    }
}
