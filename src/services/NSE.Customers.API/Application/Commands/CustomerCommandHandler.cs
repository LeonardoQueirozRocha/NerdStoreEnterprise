using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using NSE.Customers.API.Models;

namespace NSE.Customers.API.Application.Commands
{
    public class CustomerCommandHandler : CommandHandler, IRequestHandler<CustomerRegisterCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(CustomerRegisterCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(message.Id, message.Name, message.Email, message.Cpf);

            // Validacoes de negocio

            // Persistir no banco
            if (true) // Ja existe um cliente com o cpf informado
            {
                AddError("Este CPF já está em uso.");
                return ValidationResult;
            }

            return message.ValidationResult;
        }
    }
}
