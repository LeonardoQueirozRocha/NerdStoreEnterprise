using Microsoft.AspNetCore.Mvc;
using NSE.WebApi.Core.Controllers;
using NSE.WebApp.MVC.Models.Cart;

namespace NSE.WebApp.MVC.Controllers
{
    [Route("cart")]
    public class CartController : MainController
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [Route("add-item")]
        public async Task<IActionResult> AddCartItem(ProductItemViewModel productItemViewModel)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("update-item")]
        public async Task<IActionResult> UpdateCartItem(Guid productId, int quantity)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("delete-item")]
        public async Task<IActionResult> RemoveCartItem(Guid productId)
        {
            return RedirectToAction("Index");
        }
    }
}
