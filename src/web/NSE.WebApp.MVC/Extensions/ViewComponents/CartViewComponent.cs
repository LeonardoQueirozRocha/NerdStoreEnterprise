using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Extensions.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _cartService.GetCartAsync() ?? new CartViewModel());
        }
    }
}
