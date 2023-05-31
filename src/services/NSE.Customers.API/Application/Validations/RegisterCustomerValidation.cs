using FluentValidation;
using NSE.Core.DomainObjects;
using NSE.Customers.API.Application.Commands;

namespace NSE.Customers.API.Application.Validations
{
    public class RegisterCustomerValidation : AbstractValidator<CustomerRegisterCommand>
    {
        public RegisterCustomerValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido.");

            RuleFor(c => c.Name)
                .NotEmpty()
                    .WithMessage("O nome do cliente não foi informado.");

            RuleFor(c => c.Cpf)
                .Must(HaveValidCpf)
                    .WithMessage("O CPF informado não é válido.");

            RuleFor(c => c.Email)
                .Must(HaveValidEmail)
                    .WithMessage("O e-mail informado não é válido.");
        }

        protected static bool HaveValidCpf(string cpf) => Cpf.Validate(cpf);

        protected static bool HaveValidEmail(string email) => Email.Validate(email);
    }
}
