using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Controllers.Base;
using NSE.WebApp.MVC.Models.Customer;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Controllers
{
    [Authorize]
    public class CustomerController : MainController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route("new-address")]
        [HttpPost]
        public async Task<IActionResult> NewAddress(AddressViewModel address)
        {
            var response = await _customerService.AddAddressAsync(address);

            if (HasResponseErrors(response))
                TempData["Errors"] = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            return RedirectToAction("DeliveryAddress", "Order");
        }
    }
}
