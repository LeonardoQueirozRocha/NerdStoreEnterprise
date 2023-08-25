using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NSE.Cart.API.Data;
using NSE.Cart.API.Model;
using NSE.WebApi.Core.User.Interfaces;

namespace NSE.Cart.API.Services.gRPC;

[Authorize]
public class CartGrpcService : ShoppingCart.ShoppingCartBase
{
    private readonly ILogger<CartGrpcService> _logger;
    private readonly IAspNetUser _user;
    private readonly CartContext _context;

    public CartGrpcService(
        ILogger<CartGrpcService> logger,
        IAspNetUser user,
        CartContext context)
    {
        _logger = logger;
        _user = user;
        _context = context;
    }

    public override async Task<CustomerCartResponse> GetCart(GetCartRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Chamando GetCart");

        return MapCustomerCartToProtoResponse(await GetCustomerCartAsync());
    }

    private async Task<CustomerCart> GetCustomerCartAsync()
    {
        var customerCart = await _context.CustomerCart
            .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CustomerId == _user.GetUserId());

        return customerCart ?? new CustomerCart();
    }

    private static CustomerCartResponse MapCustomerCartToProtoResponse(CustomerCart cart)
    {
        var protoCart = new CustomerCartResponse
        {
            Id = cart.Id.ToString(),
            Customerid = cart.CustomerId.ToString(),
            Totalvalue = (double)cart.TotalValue,
            Discount = (double)cart.Discount,
            Usedvoucher = cart.UsedVoucher
        };

        if (cart.Voucher != null)
        {
            protoCart.Voucher = new VoucherResponse
            {
                Code = cart.Voucher.Code,
                Percentage = (double?)cart.Voucher.Percentage ?? 0,
                Discountvalue = (double?)cart.Voucher.DiscountValue ?? 0,
                Discounttype = (int)cart.Voucher.DiscountType
            };
        }

        protoCart.Items.AddRange(cart.Items.Select(item => new CartItemResponse
        {
            Id = item.Id.ToString(),
            Name = item.Name,
            Image = item.Image,
            Productid = item.ProductId.ToString(),
            Quantity = item.Quantity,
            Value = (double)item.Value
        }));

        return protoCart;
    }
}
