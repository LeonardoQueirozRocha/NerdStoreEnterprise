namespace NSE.WebApp.MVC.Models.Cart
{
    public class CartViewModel
    {
        public decimal TotalValue { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
    }
}
