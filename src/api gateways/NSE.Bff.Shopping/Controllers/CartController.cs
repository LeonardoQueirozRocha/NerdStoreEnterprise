using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Bff.Shopping.Models;
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
        private readonly IOrderService _orderService;

        public CartController(
            ICartService cartService,
            ICatalogService catalogService,
            IOrderService orderService)
        {
            _cartService = cartService;
            _catalogService = catalogService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return CustomResponse(await _cartService.GetCartAsync());
        }

        [HttpGet("cart-quantity")]
        public async Task<int> GetCartQuantity()
        {
            var cart = await _cartService.GetCartAsync();
            return cart?.Items.Sum(i => i.Quantity) ?? 0;
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddCartItem(CartItemDTO productItem)
        {
            var product = await _catalogService.GetByIdAsync(productItem.ProductId);

            await ValidateCartItemAsync(product, productItem.Quantity);

            if (!IsValid()) return CustomResponse();

            productItem.Name = product.Name;
            productItem.Value = product.Value;
            productItem.Image = product.Image;

            var response = await _cartService.AddCartItemAsync(productItem);

            return CustomResponse(response);
        }

        [HttpPut("items/{productId:guid}")]
        public async Task<IActionResult> UpdateCartItem(Guid productId, CartItemDTO productItem)
        {
            var product = await _catalogService.GetByIdAsync(productId);

            await ValidateCartItemAsync(product, productItem.Quantity);

            if (!IsValid()) return CustomResponse();

            var response = await _cartService.UpdateCartItemAsync(productId, productItem);

            return CustomResponse(response);
        }

        [HttpDelete("items/{productId:guid}")]
        public async Task<IActionResult> DeleteCartItem(Guid productId)
        {
            var product = await _catalogService.GetByIdAsync(productId);

            if (product == null)
            {
                AddProcessingError("Produto inexistente");
                return CustomResponse();
            }

            var response = await _cartService.DeleteCartItemAsync(productId);

            return CustomResponse(response);
        }

        [HttpPost("apply-voucher")]
        public async Task<IActionResult> ApplyVoucher([FromBody] string voucherCode)
        {
            var voucher = await _orderService.GetVoucherByCodeAsync(voucherCode);

            if (voucher is null)
            {
                AddProcessingError("Voucher inválido ou não encontrado!");
                return CustomResponse();
            }

            var response = await _cartService.ApplyCartVoucherAsync(voucher);

            return CustomResponse(response);
        }

        private async Task ValidateCartItemAsync(ProductItemDTO product, int quantity)
        {
            if (product == null) AddProcessingError("Produto inexistente");
            if (quantity < 1) AddProcessingError($"Escolha ao menos uma unidade do produto {product.Name}");

            var cart = await _cartService.GetCartAsync();
            var cartItem = cart.Items.FirstOrDefault(p => p.ProductId == product.Id);

            if (cartItem != null && cartItem.Quantity + quantity > product.QuantityInStock)
            {
                AddProcessingError($"O produto {product.Name} possui {product.QuantityInStock} unidades em estoque, você selecionou {quantity}");
                return;
            }

            if (quantity > product.QuantityInStock) AddProcessingError($"O produto {product.Name} possui {product.QuantityInStock} unidades em estoque, você selecionou {quantity}");

        }
    }
}
