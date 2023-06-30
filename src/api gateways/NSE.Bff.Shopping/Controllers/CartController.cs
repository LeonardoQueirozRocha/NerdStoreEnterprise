using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Bff.Shopping.Services.Interfaces;
using NSE.WebApi.Core.Controllers;

namespace NSE.Bff.Shopping.Controllers
{
    [Authorize]
    [Route("shopping/cart")]
    public class CartController : MainController
    {
        private readonly ICartService _cartService;
        private readonly ICatalogService _catalogService;

        public CartController(ICartService cartService, ICatalogService catalogService)
        {
            _cartService = cartService;
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return CustomResponse();
        }

        [HttpGet("cart-quantity")]
        public async Task<IActionResult> GetCartQuantity()
        {
            return CustomResponse();
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddCartItem()
        {
            return CustomResponse();
        }

        [HttpPut("items/{productId:guid}")]
        public async Task<IActionResult> UpdateCartItem()
        {
            return CustomResponse();
        }

        [HttpDelete("items/{productId:guid}")]
        public async Task<IActionResult> DeleteCartItem()
        {
            return CustomResponse();
        }
    }
}
