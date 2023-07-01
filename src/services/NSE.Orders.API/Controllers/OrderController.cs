using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApi.Core.Controllers;

namespace NSE.Orders.API.Controllers
{
    [Authorize]
    [Route("orders")]
    public class OrderController : MainController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return CustomResponse();
        }
    }
}
