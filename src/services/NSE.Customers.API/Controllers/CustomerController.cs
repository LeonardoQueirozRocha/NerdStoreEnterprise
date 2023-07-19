using Microsoft.AspNetCore.Mvc;
using NSE.Core.Mediator;
using NSE.Customers.API.Application.Commands;
using NSE.Customers.API.Models.Interfaces;
using NSE.WebApi.Core.Controllers;
using NSE.WebApi.Core.User.Interfaces;

namespace NSE.Customers.API.Controllers
{
    [Route("customers")]
    public class CustomerController : MainController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public CustomerController(
            ICustomerRepository customerRepository, 
            IMediatorHandler mediator,
            IAspNetUser user)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
            _user = user;
        }

        [HttpGet("addresses")]
        public async Task<IActionResult> GetAddress()
        {
            var address = await _customerRepository.GetAddressByIdAsync(_user.GetUserId());
            return address == null ? NotFound() : CustomResponse(address);
        }

        [HttpPost("addresses")]
        public async Task<IActionResult> AddAddress(AddAddressCommand address)
        {
            address.CustomerId = _user.GetUserId();
            return CustomResponse(await _mediator.SendCommandAsync(address));
        }
    }
}
