using NSE.Core.DomainObjects;

namespace NSE.Orders.Domain.Vouchers
{
    public class Voucher : Entity, IAggregateRoot
    {
        public string Code { get; private set; }
        public decimal? Percentage { get; private set; }
        public decimal? DiscountValue { get; private set; }
        public int Quantity { get; private set; }
        public DiscountVoucherType DiscountType { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? DateOfUse { get; private set; }
        public DateTime ValidationDate { get; private set; }
        public bool Active { get; private set; }
        public bool Used { get; private set; }
    }
}
