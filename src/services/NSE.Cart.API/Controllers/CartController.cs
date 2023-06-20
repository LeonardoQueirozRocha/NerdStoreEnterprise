using Microsoft.AspNetCore.Authorization;
using NSE.WebApi.Core.Controllers;

namespace NSE.Cart.API.Controllers
{
    [Authorize]
    public class CartController : MainController
    {
    }
}
