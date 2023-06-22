using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Cart.API.Model;
using NSE.WebApi.Core.Controllers;
using NSE.WebApi.Core.User.Interfaces;

namespace NSE.Cart.API.Controllers
{
    [Authorize]
    [Route("cart")]
    public class CartController : MainController
    {
        private readonly IAspNetUser _user;

        public CartController(IAspNetUser user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<CustomerCart> GetCart()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(CartItem item)
        {
            return CustomResponse();
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateCartItem(Guid productId, CartItem item)
        {
            return CustomResponse();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveCartItem(Guid productId)
        {
            return CustomResponse();
        }
    }
}
