using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using NSE.Bff.Shopping.Models;
using NSE.Bff.Shopping.Services.Interfaces;
using NSE.WebApi.Core.Controllers;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace NSE.Bff.Shopping.Controllers
{
    [Authorize]
    [Route("shopping/orders")]
    public class OrderController : MainController
    {
        private readonly ICatalogService _catalogService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(
            ICatalogService catalogService,
            ICartService cartService,
            IOrderService orderService,
            ICustomerService customerService)
        {
            _catalogService = catalogService;
            _cartService = cartService;
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDTO order)
        {
            var cart = await _cartService.GetCartAsync();
            var products = await _catalogService.GetItemsAsync(cart.Items.Select(p => p.ProductId));
            var address = await _customerService.GetAddressAsync();

            if (!await ValidateCartProductsAsync(cart, products)) return CustomResponse();

            PopulateOrderData(cart, address, order);

            return CustomResponse(await _orderService.ConcludeOrderAsync(order));
        }

        [HttpGet("last")]
        public async Task<IActionResult> LastOrder()
        {
            var order = await _orderService.GetLastOrderAsync();

            if (order is null)
            {
                AddProcessingError("Pedido não encontrado!");
                return CustomResponse();
            }

            return CustomResponse(order);
        }

        [HttpGet("customer-list")]
        public async Task<IActionResult> ListByCustomer()
        {
            var orders = await _orderService.GetListByCustomerIdAsync();

            return orders == null ? NotFound() : CustomResponse(orders);
        }

        private async Task<bool> ValidateCartProductsAsync(CartDTO cart, IEnumerable<ProductItemDTO> products)
        {
            if (!ValidateUnavailableItems(cart, products)) return false;

            foreach (var cartItem in cart.Items) await ValidateCartItemAsync(cartItem, products);

            return true;
        }

        private bool ValidateUnavailableItems(CartDTO cart, IEnumerable<ProductItemDTO> products)
        {
            if (cart.Items.Count != products.Count())
            {
                var unavailableItems = cart.Items
                    .Select(c => c.ProductId)
                        .Except(products.Select(p => p.Id))
                            .ToList();

                foreach (var unavailableItem in unavailableItems)
                {
                    var cartItem = cart.Items.FirstOrDefault(c => c.ProductId == unavailableItem);
                    AddProcessingError($"O item {cartItem.Name} não está mais disponível no catálogo, o remova do carrinho para prosseguir com a compra");
                }

                return false;
            }

            return true;
        }

        private async Task<bool> ValidateCartItemAsync(CartItemDTO cartItem, IEnumerable<ProductItemDTO> products)
        {
            var catalogProduct = products.FirstOrDefault(p => p.Id == cartItem.ProductId);

            if (catalogProduct.Value != cartItem.Value)
            {
                var errorMessage = $"O produto {cartItem.Name} mudou de valor (de: " +
                                   $"{string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", cartItem.Value)} para: " +
                                   $"{string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", catalogProduct.Value)}) desde que foi adicionado ao carrinho.";

                AddProcessingError(errorMessage);

                if (!await RemoveCartItemAsync(cartItem)) return false;

                cartItem.Value = catalogProduct.Value;

                if (!await AddCartItemAsync(cartItem)) return false;

                CleanProcessingErrors();
                AddProcessingError(errorMessage + " Atualizamos o valor em seu carrinho, realize a conferência do pedido e se preferir remova o produto");

                return false;
            }

            return true;
        }

        private async Task<bool> RemoveCartItemAsync(CartItemDTO cartItem)
        {
            var response = await _cartService.DeleteCartItemAsync(cartItem.ProductId);

            if (HasResponseErrors(response))
            {
                AddProcessingError($"Não foi possível remover automaticamente o produto {cartItem.Name} do seu carrinho, _" +
                                   "remova e adicione novamente caso ainda deseje comprar este item");

                return false;
            }

            return true;
        }

        private async Task<bool> AddCartItemAsync(CartItemDTO cartItem)
        {
            var response = await _cartService.AddCartItemAsync(cartItem);

            if (HasResponseErrors(response))
            {
                AddProcessingError($"Não foi possível atualizar automaticamente o produto {cartItem.Name} do seu carrinho, _" +
                                   "adicione novamente caso ainda deseje comprar este item");

                return false;
            }

            return true;
        }

        private void PopulateOrderData(CartDTO cart, AddressDTO address, OrderDTO order)
        {
            order.VoucherCode = cart.Voucher?.Code;
            order.UsedVoucher = cart.UsedVoucher;
            order.TotalValue = cart.TotalValue;
            order.Discount = cart.Discount;
            order.OrderItems = cart.Items;
            order.Address = address;
        }
    }
}
