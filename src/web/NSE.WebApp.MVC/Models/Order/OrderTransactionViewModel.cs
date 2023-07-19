using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Models.Customer;

namespace NSE.WebApp.MVC.Models.Order
{
    public class OrderTransactionViewModel
    {
        #region Order
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }
        public string VoucherCode { get; set; }
        public bool UsedVoucher { get; set; }

        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        #endregion

        #region Address
        public AddressViewModel Address { get; set; }
        #endregion

    }
}
