using FluentValidation;

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
        public CustomerCart CustomerCart { get; set; }

        internal void AttachCart(Guid cartId) => CartId = cartId;

        internal decimal CalculateValue() => Quantity * Value;

        internal void AddUnits(int units) => Quantity += units;

        internal bool IsValid() => new OrdemItemValidation().Validate(this).IsValid;

        public class OrdemItemValidation : AbstractValidator<CartItem>
        {
            public OrdemItemValidation()
            {
                RuleFor(c => c.ProductId)
                    .NotEmpty()
                        .WithMessage("Id do produto inválido");

                RuleFor(c => c.Name)
                    .NotEmpty()
                        .WithMessage("O nome do produto não foi informado");

                RuleFor(c => c.Quantity)
                    .GreaterThan(0)
                        .WithMessage("A quantidade mínima de um item é 1");

                RuleFor(c => c.Quantity)
                    .LessThan(CustomerCart.MAX_ITEM_QUANTITY)
                        .WithMessage($"A quantidade máxima de um item é {CustomerCart.MAX_ITEM_QUANTITY}");

                RuleFor(c => c.Value)
                    .GreaterThan(0)
                        .WithMessage("O valor do item precisa ser maior que 0");
            }
        }
    }
}
