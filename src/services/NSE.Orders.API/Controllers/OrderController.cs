using Microsoft.AspNetCore.Mvc;
using NSE.Core.Mediator;
using NSE.Orders.API.Application.Commands;
using NSE.Orders.API.Application.Queries.Interfaces;
using NSE.WebApi.Core.Controllers;
using NSE.WebApi.Core.User.Interfaces;

namespace NSE.Orders.API.Controllers
{
    [Route("orders")]
    public class OrderController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;
        private readonly IOrderQueries _orderQueries;

        public OrderController(
            IMediatorHandler mediator,
            IAspNetUser user,
            IOrderQueries orderQueries)
        {
            _mediator = mediator;
            _user = user;
            _orderQueries = orderQueries;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderCommand order)
        {
            order.CustomerId = _user.GetUserId();
            return CustomResponse(await _mediator.SendCommandAsync(order));
        }

        [HttpGet("last")]
        public async Task<IActionResult> LastOrder()
        {
            var order = await _orderQueries.GetLastOrderAsync(_user.GetUserId());
            return order == null ? NotFound() : CustomResponse(order);
        }

        [HttpGet("customer-list")]
        public async Task<IActionResult> ListByCustomer()
        {
            var orders = await _orderQueries.GetListByCustomerIdAsync(_user.GetUserId());
            return orders == null ? NotFound() : CustomResponse(orders);
        }
    }
}
