namespace NSE.WebApp.MVC.Models.Cart
{
    public class CartViewModel
    {
        public decimal TotalValue { get; set; }
        public List<ProductItemViewModel> Items { get; set; } = new List<ProductItemViewModel>();
    }
}
