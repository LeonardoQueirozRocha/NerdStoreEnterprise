using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSE.Cart.API.Data;
using NSE.Cart.API.Model;
using NSE.WebApi.Core.Controllers;
using NSE.WebApi.Core.User.Interfaces;

namespace NSE.Cart.API.Controllers
{
    [Authorize]
    [Route("cart")]
    public class CartController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly CartContext _context;

        public CartController(IAspNetUser user, CartContext context)
        {
            _user = user;
            _context = context;
        }

        [HttpGet]
        public async Task<CustomerCart> GetCart()
        {
            return await GetCustomerCartAsync() ?? new CustomerCart();
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(CartItem item)
        {
            var cart = await GetCustomerCartAsync();

            if (cart == null)
                HandleNewCart(item);
            else
                HandleExistingCart(cart, item);

            if (!IsValid()) return CustomResponse();

            await SaveCartAsync();

            return CustomResponse();
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateCartItem(Guid productId, CartItem item)
        {
            return CustomResponse();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveCartItem(Guid productId)
        {
            return CustomResponse();
        }

        private async Task<CustomerCart> GetCustomerCartAsync()
        {
            return await _context.CustomerCart
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CustomerId == _user.GetUserId());
        }

        private void HandleNewCart(CartItem item)
        {
            var cart = new CustomerCart(_user.GetUserId());

            cart.AddItem(item);

            _context.CustomerCart.Add(cart);
        }

        private void HandleExistingCart(CustomerCart cart, CartItem item)
        {
            var existingProductItem = cart.CartItemExists(item);

            cart.AddItem(item);

            if (existingProductItem)
                _context.CartItems.Update(cart.GetByProductId(item.ProductId));
            else
                _context.CartItems.Add(item);

            _context.CustomerCart.Update(cart);
        }

        private async Task SaveCartAsync()
        {
            var result = await _context.SaveChangesAsync();

            if (result <= 0) AddProcessingError("Não foi possível persistir os dados no banco");
        }
    }
}
