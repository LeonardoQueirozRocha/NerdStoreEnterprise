using Microsoft.AspNetCore.Mvc;
using NSE.Core.Mediator;
using NSE.Customers.API.Application.Commands;
using NSE.WebApi.Core.Controllers;

namespace NSE.Customers.API.Controllers
{
    public class CustomerController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public CustomerController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("customers")]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler.SendCommandAsync(
                new CustomerRegisterCommand(Guid.NewGuid(), "Leonardo", "leonardo@teste.com", "77898377028"));

            return CustomResponse(result);
        }
    }
}
