﻿using NSE.Core.Communication;
using NSE.WebApp.MVC.Models.Cart;
using NSE.WebApp.MVC.Models.Customer;
using NSE.WebApp.MVC.Models.Order;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface IShoppingBffService
    {
        Task<CartViewModel> GetCartAsync();
        Task<int> GetCartQuantityAsync();
        Task<ResponseResult> AddCartItemAsync(CartItemViewModel product);
        Task<ResponseResult> UpdateCartItemAsync(Guid productId, CartItemViewModel product);
        Task<ResponseResult> RemoveCartItemAsync(Guid productId);
        Task<ResponseResult> ApplyCartVoucherAsync(string voucher);
        OrderTransactionViewModel MapForOrder(CartViewModel cart, AddressViewModel address);
    }
}
