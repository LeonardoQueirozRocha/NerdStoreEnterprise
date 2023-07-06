namespace NSE.WebApp.MVC.Models.Cart
{
    public class CartViewModel
    {
        public decimal TotalValue { get; set; }
        public bool UsedVoucher { get; set; }
        public decimal Discount { get; set; }
        public VoucherViewModel Voucher { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
    }
}
