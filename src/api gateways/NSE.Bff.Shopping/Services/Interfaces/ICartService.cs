using NSE.Bff.Shopping.Models;
using NSE.Core.Communication;

namespace NSE.Bff.Shopping.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartDTO> GetCartAsync();
        Task<ResponseResult> AddCartItemAsync(CartItemDTO product);
        Task<ResponseResult> UpdateCartItemAsync(Guid productId, CartItemDTO cart);
        Task<ResponseResult> DeleteCartItemAsync(Guid productId);
        Task<ResponseResult> ApplyCartVoucherAsync(VoucherDTO voucher);
    }
}
