using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Models.Error;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartViewModel> GetCartAsync();
        Task<ResponseResult> AddCartItemAsync(ProductItemViewModel product);
        Task<ResponseResult> UpdateCartItemAsync(Guid productId, ProductItemViewModel product);
        Task<ResponseResult> RemoveCartItemAsync(Guid productId);
    }
}
