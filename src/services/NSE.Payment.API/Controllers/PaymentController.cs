using Microsoft.AspNetCore.Mvc;
using NSE.WebApi.Core.Controllers;

namespace NSE.Payment.API.Controllers
{
    [Route("payments")]
    public class PaymentController : MainController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
