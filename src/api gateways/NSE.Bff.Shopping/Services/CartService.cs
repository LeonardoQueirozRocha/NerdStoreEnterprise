using Microsoft.Extensions.Options;
using NSE.Bff.Shopping.Extensions;
using NSE.Bff.Shopping.Models;
using NSE.Bff.Shopping.Services.Base;
using NSE.Bff.Shopping.Services.Interfaces;
using NSE.Core.Communication;

namespace NSE.Bff.Shopping.Services;


public class CartService : BaseService, ICartService
{
    private readonly HttpClient _httpClient;

    public CartService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(settings.Value.CartUrl);
    }

    public async Task<CartDTO> GetCartAsync()
    {
        var response = await _httpClient.GetAsync("/cart/");

        HandleResponseErrors(response);

        return await DeserializeResponseObject<CartDTO>(response);
    }

    public async Task<ResponseResult> AddCartItemAsync(CartItemDTO product)
    {
        var itemContent = GetContent(product);

        var response = await _httpClient.PostAsync("/cart/", itemContent);

        if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

        return Ok();
    }

    public async Task<ResponseResult> UpdateCartItemAsync(Guid productId, CartItemDTO cart)
    {
        var itemContent = GetContent(cart);

        var response = await _httpClient.PutAsync($"/cart/{cart.ProductId}", itemContent);

        if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

        return Ok();
    }

    public async Task<ResponseResult> DeleteCartItemAsync(Guid productId)
    {
        var response = await _httpClient.DeleteAsync($"/cart/{productId}");

        if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

        return Ok();
    }

    public async Task<ResponseResult> ApplyCartVoucherAsync(VoucherDTO voucher)
    {
        var itemContent = GetContent(voucher);
        var response = await _httpClient.PostAsync("/cart/apply-voucher/", itemContent);

        if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

        return Ok();
    }
}
