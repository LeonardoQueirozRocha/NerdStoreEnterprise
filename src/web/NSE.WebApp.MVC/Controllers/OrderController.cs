using Microsoft.AspNetCore.Mvc;
using NSE.WebApi.Core.Controllers;
using NSE.WebApp.MVC.Models.Order;
using NSE.WebApp.MVC.Services.Interfaces;
using System.Diagnostics.Contracts;

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

        [HttpGet]
        [Route("payment")]
        public async Task<IActionResult> Payment()
        {
            var cart = await _shoppingBffService.GetCartAsync();

            if (!cart.Items.Any()) return RedirectToAction("Index", "Cart");

            var order = _shoppingBffService.MapForOrder(cart, null);

            return View(order);
        }

        [HttpPost]
        [Route("complete-order")]
        public async Task<IActionResult> CompleteOrder(OrderTransactionViewModel orderTransaction)
        {
            if (!ModelState.IsValid)
                return View("Payment", _shoppingBffService.MapForOrder(await _shoppingBffService.GetCartAsync(), null));

            var response = await _shoppingBffService.CompleteOrderAsync(orderTransaction);

            if (HasResponseErrors(response))
            {
                var cart = await _shoppingBffService.GetCartAsync();

                if (!cart.Items.Any()) return RedirectToAction("Index", "Cart");

                var order = _shoppingBffService.MapForOrder(cart, null);

                return View(order);
            }

            return RedirectToAction("CompletedOrder");
        }

        [HttpGet]
        [Route("completed-order")]
        public async Task<IActionResult> CompletedOrder()
        {
            return View("OrderConfirmation", await _shoppingBffService.GetLastOrderAsync());
        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> MyOrders()
        {
            return View(await _shoppingBffService.GetListByCustomerIdAsync());
        }
    }
}
