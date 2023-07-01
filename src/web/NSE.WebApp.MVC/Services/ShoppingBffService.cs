using Microsoft.Extensions.Options;
using NSE.Core.Communication;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Services.Base;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Services
{
    public class ShoppingBffService : BaseService, IShoppingBffService
    {
        private readonly HttpClient _httpClient;

        public ShoppingBffService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ShoppingBffUrl);
        }

        public async Task<CartViewModel> GetCartAsync()
        {
            var response = await _httpClient.GetAsync("/shopping/cart/");

            HandleResponseErrors(response);

            return await DeserializeResponseObject<CartViewModel>(response);
        }

        public async Task<int> GetCartQuantityAsync()
        {
            var response = await _httpClient.GetAsync("/shopping/cart/cart-quantity");

            HandleResponseErrors(response);

            return await DeserializeResponseObject<int>(response);
        }

        public async Task<ResponseResult> AddCartItemAsync(CartItemViewModel product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PostAsync("/shopping/cart/items", itemContent);

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> UpdateCartItemAsync(Guid productId, CartItemViewModel product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PutAsync($"/shopping/cart/items/{productId}", itemContent);

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> RemoveCartItemAsync(Guid productId)
        {
            var response = await _httpClient.DeleteAsync($"/shopping/cart/items/{productId}");

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }
    }
}
