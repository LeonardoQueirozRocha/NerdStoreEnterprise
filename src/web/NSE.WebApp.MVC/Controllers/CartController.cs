using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Controllers.Base;
using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Controllers
{
    [Route("cart")]
    public class CartController : MainController
    {
        private readonly IShoppingBffService _shoppingBffService;

        public CartController(IShoppingBffService cartService)
        {
            _shoppingBffService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _shoppingBffService.GetCartAsync());
        }

        [HttpPost]
        [Route("add-item")]
        public async Task<IActionResult> AddCartItem(CartItemViewModel cartItem)
        {
            var response = await _shoppingBffService.AddCartItemAsync(cartItem);

            if (HasResponseErrors(response)) return View("Index", await _shoppingBffService.GetCartAsync());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("update-item")]
        public async Task<IActionResult> UpdateCartItem(Guid productId, int quantity)
        {
            var item = new CartItemViewModel { ProductId = productId, Quantity = quantity };
            var response = await _shoppingBffService.UpdateCartItemAsync(productId, item);

            if (HasResponseErrors(response)) return View("Index", await _shoppingBffService.GetCartAsync());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("delete-item")]
        public async Task<IActionResult> RemoveCartItem(Guid productId)
        {
            var response = await _shoppingBffService.RemoveCartItemAsync(productId);

            if (HasResponseErrors(response)) return View("Index", await _shoppingBffService.GetCartAsync());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("apply-voucher")]
        public async Task<IActionResult> ApplyVoucher(string voucherCode)
        {
            var response = await _shoppingBffService.ApplyCartVoucherAsync(voucherCode);

            if (HasResponseErrors(response)) return View("Index", await _shoppingBffService.GetCartAsync());

            return RedirectToAction("Index");
        }
    }
}
