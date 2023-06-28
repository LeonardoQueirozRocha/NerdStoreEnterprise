using FluentValidation;
using System.Text.Json.Serialization;

namespace NSE.Cart.API.Model
{
    public class CartItem
    {
        public CartItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public string Image { get; set; }

        public Guid CartId { get; set; }

        [JsonIgnore]
        public CustomerCart CustomerCart { get; set; }

        internal void AttachCart(Guid cartId) => CartId = cartId;

        internal decimal CalculateValue() => Quantity * Value;

        internal void AddUnits(int units) => Quantity += units;

        internal void UpdateUnits(int units)
        {
            Quantity = units;
        }

        internal bool IsValid() => new CartItemValidator().Validate(this).IsValid;

        public class CartItemValidator : AbstractValidator<CartItem>
        {
            public CartItemValidator()
            {
                RuleFor(c => c.ProductId)
                    .NotEmpty()
                        .WithMessage("Id do produto inválido");

                RuleFor(c => c.Name)
                    .NotEmpty()
                        .WithMessage("O nome do produto não foi informado");

                RuleFor(c => c.Quantity)
                    .GreaterThan(0)
                        .WithMessage(item => $"A quantidade mínima para o {item.Name} é 1");

                RuleFor(c => c.Quantity)
                    .LessThanOrEqualTo(CustomerCart.MAX_ITEM_QUANTITY)
                        .WithMessage(item => $"A quantidade máxima do {item.Name} é {CustomerCart.MAX_ITEM_QUANTITY}");

                RuleFor(c => c.Value)
                    .GreaterThan(0)
                        .WithMessage(item => $"O valor do {item.Name} precisa ser maior que 0");
            }
        }
    }
}
