using Microsoft.Extensions.Options;
using NSE.Core.Communication;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Models.Customer;
using NSE.WebApp.MVC.Models.Order;
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

        #region Cart
        public async Task<CartViewModel> GetCartAsync()
        {
            var response = await _httpClient.GetAsync("/shopping/cart/");

            HandleResponseErrors(response);

            return await DeserializeResponseObject<CartViewModel>(response);
        }

        public async Task<int> GetCartQuantityAsync()
        {
            var response = await _httpClient.GetAsync("/shopping/cart/cart-quantity/");

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

        public async Task<ResponseResult> ApplyCartVoucherAsync(string voucher)
        {
            var itemContent = GetContent(voucher);
            var response = await _httpClient.PostAsync("/shopping/cart/apply-voucher", itemContent);

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }
        #endregion

        #region Order
        public async Task<ResponseResult> CompleteOrderAsync(OrderTransactionViewModel orderTransaction)
        {
            var orderContent = GetContent(orderTransaction);
            var response = await _httpClient.PostAsync("/shopping/orders/", orderContent);

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }

        public async Task<OrderViewModel> GetLastOrderAsync()
        {
            var response = await _httpClient.GetAsync("/shopping/orders/last/");

            HandleResponseErrors(response);

            return await DeserializeResponseObject<OrderViewModel>(response);
        }

        public async Task<IEnumerable<OrderViewModel>> GetListByCustomerIdAsync()
        {
            var response = await _httpClient.GetAsync("/shopping/orders/customer-list");

            HandleResponseErrors(response);

            return await DeserializeResponseObject<IEnumerable<OrderViewModel>>(response);
        }

        public OrderTransactionViewModel MapForOrder(CartViewModel cart, AddressViewModel address)
        {
            var order = new OrderTransactionViewModel
            {
                TotalValue = cart.TotalValue,
                Items = cart.Items,
                Discount = cart.Discount,
                UsedVoucher = cart.UsedVoucher,
                VoucherCode = cart.Voucher?.Code
            };

            if (address != null)
            {
                order.Address = new AddressViewModel
                {
                    PublicArea = address.PublicArea,
                    Number = address.Number,
                    Neightborhood = address.Neightborhood,
                    ZipCode = address.ZipCode,
                    Complement = address.Complement,
                    City = address.City,
                    State = address.State,
                };
            }

            return order;
        }
        #endregion
    }
}
