using Microsoft.Extensions.Options;
using NSE.Core.Communication;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Services.Base;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Services
{
    public class CartService : BaseService, ICartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CartUrl);
        }

        public async Task<CartViewModel> GetCartAsync()
        {
            var response = await _httpClient.GetAsync("/cart/");

            HandleResponseErrors(response);

            return await DeserializeResponseObject<CartViewModel>(response);
        }

        public async Task<ResponseResult> AddCartItemAsync(ProductItemViewModel product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PostAsync("/cart/", itemContent);

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> UpdateCartItemAsync(Guid productId, ProductItemViewModel product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PutAsync($"/cart/{productId}", itemContent);

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> RemoveCartItemAsync(Guid productId)
        {
            var response = await _httpClient.DeleteAsync($"/cart/{productId}");

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }
    }
}
