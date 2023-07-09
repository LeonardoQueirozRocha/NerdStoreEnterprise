using NSE.Core.DomainObjects;
using NSE.Orders.Domain.Orders.Enums;
using NSE.Orders.Domain.Vouchers;
using NSE.Orders.Domain.Vouchers.Enums;

namespace NSE.Orders.Domain.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        protected Order() { }

        public Order(
            Guid customerId, 
            decimal totalValue, 
            List<OrderItem> orderItems, 
            bool usedVoucher = false, 
            decimal discount = 0, 
            Guid? voucherId = null)
        {
            CustomerId = customerId;
            TotalValue = totalValue;
            _orderItems = orderItems;
            Discount = discount;
            UsedVoucher = usedVoucher;
            VoucherId = voucherId;
        }

        public int Code { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool UsedVoucher { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalValue { get; private set; }
        public DateTime CreationDate { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Address Address { get; private set; }

        // EF Rel.
        public Voucher Voucher { get; set; }

        public void AuthorizeOrder() => OrderStatus = OrderStatus.Authorized;

        public void AssignVoucher(Voucher voucher)
        {
            UsedVoucher = true;
            VoucherId = voucher.Id;
            Voucher = voucher;
        }

        public void AssignAddress(Address address) => Address = address;

        public void CalculateOrderValue()
        {
            TotalValue = OrderItems.Sum(p => p.CalculateValue());
            CalculateDiscountTotalValue();
        }

        public void CalculateDiscountTotalValue()
        {
            if (!UsedVoucher) return;

            decimal discount = 0;
            var value = TotalValue;

            if (Voucher.DiscountType == DiscountVoucherType.Percentage)
            {
                if (Voucher.Percentage.HasValue)
                {
                    discount = (value * Voucher.Percentage.Value) / 100;
                    value -= discount;
                }
            }
            else
            {
                if (Voucher.DiscountValue.HasValue)
                {
                    discount = Voucher.DiscountValue.Value;
                    value -= discount;
                }
            }

            TotalValue = value < 0 ? 0 : value;
            Discount = discount;
        }
    }
}
