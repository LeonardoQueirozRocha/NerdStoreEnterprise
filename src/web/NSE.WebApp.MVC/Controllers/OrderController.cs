using Microsoft.AspNetCore.Mvc;
using NSE.WebApi.Core.Controllers;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Controllers
{
    public class OrderController : MainController
    {
        private readonly ICustomerService _customerService;
        private readonly IShoppingBffService _shoppingBffService;

        public OrderController(
            ICustomerService customerService, 
            IShoppingBffService shoppingBffService)
        {
            _customerService = customerService;
            _shoppingBffService = shoppingBffService;
        }

        [HttpGet]
        [Route("delivery-address")]
        public async Task<IActionResult> DeliveryAddress()
        {
            var cart = await _shoppingBffService.GetCartAsync();

            if (!cart.Items.Any()) return RedirectToAction("Index", "Cart");

            var address = await _customerService.GetAddressAsync();
            var order = _shoppingBffService.MapForOrder(cart, address);

            return View(order);
        }
    }
}
