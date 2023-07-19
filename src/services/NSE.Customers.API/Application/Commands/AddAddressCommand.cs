using FluentValidation;
using NSE.Core.Messages;

namespace NSE.Customers.API.Application.Commands
{
    public class AddAddressCommand : Command
    {
        public AddAddressCommand() { }

        public AddAddressCommand(
            Guid customerId,
            string publicPlace,
            string number,
            string complement,
            string neighborhood,
            string zipCode,
            string city,
            string state)
        {
            AggregateId = customerId;
            CustomerId = customerId;
            PublicPlace = publicPlace;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            ZipCode = zipCode;
            City = city;
            State = state;
        }

        public Guid CustomerId { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AddressValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AddressValidator : AbstractValidator<AddAddressCommand>
        {
            public AddressValidator()
            {
                RuleFor(c => c.PublicPlace)
                    .NotEmpty()
                        .WithMessage("Informe o Logradouro");

                RuleFor(c => c.Number)
                    .NotEmpty()
                        .WithMessage("Informe o número");

                RuleFor(c => c.ZipCode)
                    .NotEmpty()
                        .WithMessage("Informe o Cep");

                RuleFor(c => c.Neighborhood)
                    .NotEmpty()
                        .WithMessage("Informe o bairro");

                RuleFor(c => c.City)
                    .NotEmpty()
                        .WithMessage("Informe a Cidade");

                RuleFor(c => c.State)
                    .NotEmpty()
                        .WithMessage("Informe o estado");
            }
        }
    }
}
