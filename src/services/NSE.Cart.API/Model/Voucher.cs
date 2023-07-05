namespace NSE.Cart.API.Model
{
    public class Voucher
    {
        public decimal? Percentage { get; set; }
        public decimal? DiscountValue { get; set; }
        public string Code { get; set; }
        public DiscountVoucherType DiscountType { get; set; }
    }

    public enum DiscountVoucherType
    {
        Percentage = 0,
        Value = 1
    }
}
