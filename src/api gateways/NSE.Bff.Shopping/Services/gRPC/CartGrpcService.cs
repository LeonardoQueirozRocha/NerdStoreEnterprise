using NSE.Bff.Shopping.Models;
using NSE.Bff.Shopping.Services.Interfaces.gRPC;
using NSE.Cart.API.Services.gRPC;

namespace NSE.Bff.Shopping.Services.gRPC;

public class CartGrpcService : ICartGrpcService
{
    private readonly ShoppingCart.ShoppingCartClient _shoppingCartClient;

    public CartGrpcService(ShoppingCart.ShoppingCartClient shoppingCartClient)
    {
        _shoppingCartClient = shoppingCartClient;
    }

    public async Task<CartDTO> GetCartAsync()
    {
        return MapCustomerCartProtoResponseToCartDTO(await _shoppingCartClient.GetCartAsync(new GetCartRequest()));
    }

    private static CartDTO MapCustomerCartProtoResponseToCartDTO(CustomerCartResponse cartResponse)
    {
        var cartDTO = new CartDTO
        {
            TotalValue = (decimal)cartResponse.Totalvalue,
            Discount = (decimal)cartResponse.Discount,
            UsedVoucher = cartResponse.Usedvoucher
        };

        if (cartResponse.Voucher != null)
        {
            cartDTO.Voucher = new VoucherDTO
            {
                Code = cartResponse.Voucher.Code,
                Percentage = (decimal?)cartResponse.Voucher.Percentage,
                DiscountValue = (decimal?)cartResponse.Voucher.Discountvalue,
                DiscountType = cartResponse.Voucher.Discounttype
            };
        }

        cartDTO.Items.AddRange(cartResponse.Items.Select(item => new CartItemDTO
        {
            Name = item.Name,
            Image = item.Image,
            ProductId = Guid.Parse(item.Productid),
            Quantity = item.Quantity,
            Value = (decimal)item.Value
        }));

        return cartDTO;
    }
}
