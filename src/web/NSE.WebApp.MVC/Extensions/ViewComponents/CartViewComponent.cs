using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Extensions.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IShoppingBffService _shoppingBffService;

        public CartViewComponent(IShoppingBffService cartService)
        {
            _shoppingBffService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _shoppingBffService.GetCartQuantityAsync());
        }
    }
}
