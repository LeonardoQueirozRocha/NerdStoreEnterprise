using FluentValidation;
using NSE.Core.Messages;
using NSE.Orders.API.Application.DTOs;

namespace NSE.Orders.API.Application.Commands
{
    public class AddOrderCommand : Command
    {
        // Order
        public Guid CustomerId { get; set; }
        public decimal TotalValue { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }

        // Voucher
        public string VoucherCode { get; set; }
        public bool UsedVoucher { get; set; }
        public decimal Discount { get; set; }

        // Address
        public AddressDTO Address { get; set; }

        // Card
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpirationDate { get; set; }
        public string CardCvv { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AddOrderValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AddOrderValidator : AbstractValidator<AddOrderCommand>
        {
            public AddOrderValidator()
            {
                RuleFor(c => c.CustomerId)
                    .NotEqual(Guid.Empty)
                        .WithMessage("Id do cliente inválido");

                RuleFor(c => c.OrderItems.Count)
                    .GreaterThan(0)
                        .WithMessage("O pedido precisa ter no minimo 1 item");

                RuleFor(c => c.TotalValue)
                    .GreaterThan(0)
                        .WithMessage("Valor do pedido inválido");

                RuleFor(c => c.CardNumber)
                    .CreditCard()
                        .WithMessage("Número de cartão inválido");

                RuleFor(c => c.CardName)
                    .NotNull()
                        .WithMessage("Nome do portador do cartão requerido");

                RuleFor(c => c.CardCvv.Length)
                    .GreaterThan(2)
                    .LessThan(5)
                        .WithMessage("O CVV do cartão precisa ter 3 ou 4 números.");

                RuleFor(c => c.CardExpirationDate)
                    .NotNull()
                        .WithMessage("Data expiração do cartão requerida.");
            }
        }
    }
}
