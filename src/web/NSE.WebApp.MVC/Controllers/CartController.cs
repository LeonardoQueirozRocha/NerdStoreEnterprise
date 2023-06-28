using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Controllers.Base;
using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Models.Catalog;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Controllers
{
    [Route("cart")]
    public class CartController : MainController
    {
        private readonly ICartService _cartService;
        private readonly ICatalogService _catalogService;

        public CartController(ICartService cartService, ICatalogService catalogService)
        {
            _cartService = cartService;
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _cartService.GetCartAsync());
        }

        [HttpPost]
        [Route("add-item")]
        public async Task<IActionResult> AddCartItem(ProductItemViewModel productItemViewModel)
        {
            var product = await _catalogService.GetByIdAsync(productItemViewModel.ProductId);

            ValidateCartItem(product, productItemViewModel.Quantity);

            if (!IsValid()) return View("Index", await _cartService.GetCartAsync());

            productItemViewModel.Name = product.Name;
            productItemViewModel.Value = product.Value;
            productItemViewModel.Image = product.Image;

            var response = await _cartService.AddCartItemAsync(productItemViewModel);

            if (HasResponseErrors(response)) return View("Index", await _cartService.GetCartAsync());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("update-item")]
        public async Task<IActionResult> UpdateCartItem(Guid productId, int quantity)
        {
            var product = await _catalogService.GetByIdAsync(productId);

            ValidateCartItem(product, quantity);

            if (!IsValid()) return View("Index", await _cartService.GetCartAsync());

            var productItem = new ProductItemViewModel { ProductId = productId, Quantity = quantity };
            var response = await _cartService.UpdateCartItemAsync(productId, productItem);

            if (HasResponseErrors(response)) return View("Index", await _cartService.GetCartAsync());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("delete-item")]
        public async Task<IActionResult> RemoveCartItem(Guid productId)
        {
            var product = await _catalogService.GetByIdAsync(productId);

            if (product == null)
            {
                AddValidationError("Produto inexistente!");
                return View("Index", await _cartService.GetCartAsync());
            }

            var response = await _cartService.RemoveCartItemAsync(productId);

            if (HasResponseErrors(response)) return View("Index", await _cartService.GetCartAsync());

            return RedirectToAction("Index");
        }

        private void ValidateCartItem(ProductViewModel product, int quantity)
        {
            if (product == null) AddValidationError("Produto inexistente");
            if (quantity < 1) AddValidationError($"Escolha ao menos uma unidade do produto {product.Name}");
            if (quantity > product.QuantityInStock) AddValidationError($"O produto {product.Name} possui {product.QuantityInStock} unidades em estoque, você selecionou {quantity}");
        }
    }
}
