using FluentValidation;
using FluentValidation.Results;

namespace NSE.Cart.API.Model
{
    public class CustomerCart
    {
        internal const int MAX_ITEM_QUANTITY = 5;

        public CustomerCart() { }

        public CustomerCart(Guid customerId)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalValue { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public ValidationResult ValidationResult { get; set; }

        internal void CalculateCartValue() => TotalValue = Items.Sum(p => p.CalculateValue());

        internal bool CartItemExists(CartItem item) => Items.Any(p => p.ProductId == item.ProductId);

        internal CartItem GetByProductId(Guid productId) => Items.FirstOrDefault(p => p.ProductId == productId);

        internal void AddItem(CartItem item)
        {
            item.AttachCart(Id);

            if (CartItemExists(item))
            {
                var existingItem = GetByProductId(item.ProductId);
                existingItem.AddUnits(item.Quantity);

                item = existingItem;
                Items.Remove(existingItem);
            }

            Items.Add(item);
            CalculateCartValue();
        }

        internal void UpdateItem(CartItem item)
        {
            item.AttachCart(Id);

            var existedItem = GetByProductId(item.ProductId);

            Items.Remove(existedItem);
            Items.Add(item);

            CalculateCartValue();
        }

        internal void UpdateUnits(CartItem item, int units)
        {
            item.UpdateUnits(units);
            UpdateItem(item);
        }

        internal void RemoveItem(CartItem item)
        {
            Items.Remove(GetByProductId(item.ProductId));
            CalculateCartValue();
        }

        internal bool IsValid()
        {
            var errors = Items.SelectMany(i => new CartItem.CartItemValidator().Validate(i).Errors).ToList();
            errors.AddRange(new CustomerCartValidator().Validate(this).Errors);
            ValidationResult = new ValidationResult(errors);

            return ValidationResult.IsValid;
        }

        public class CustomerCartValidator : AbstractValidator<CustomerCart>
        {
            public CustomerCartValidator()
            {
                RuleFor(c => c.CustomerId)
                    .NotEqual(Guid.Empty)
                        .WithMessage("Cliente não reconhecido");

                RuleFor(c => c.Items.Count)
                    .GreaterThan(0)
                        .WithMessage("O carrinho não possuí itens");

                RuleFor(c => c.TotalValue)
                    .GreaterThan(0)
                        .WithMessage("O valor total do carrinho precisa ser maior que 0");
            }
        }
    }
}
