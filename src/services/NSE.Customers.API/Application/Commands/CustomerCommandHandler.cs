using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using NSE.Customers.API.Application.Events;
using NSE.Customers.API.Models;
using NSE.Customers.API.Models.Interfaces;

namespace NSE.Customers.API.Application.Commands
{
    public class CustomerCommandHandler : 
        CommandHandler, 
        IRequestHandler<CustomerRegisterCommand, ValidationResult>, 
        IRequestHandler<AddAddressCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> Handle(CustomerRegisterCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(message.Id, message.Name, message.Email, message.Cpf);

            var existingCustomer = await _customerRepository.GetByCpfAsync(customer.Cpf.Number);

            if (existingCustomer != null)
            {
                AddError("Este CPF já está em uso.");
                return ValidationResult;
            }

            _customerRepository.Add(customer);

            customer.AddEvent(new RegisteredCustomerEvent(message.Id, message.Name, message.Email, message.Cpf));

            return await PersistDataAsync(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AddAddressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var address = new Address(
                message.PublicPlace,
                message.Number,
                message.Complement,
                message.Neighborhood,
                message.ZipCode,
                message.City,
                message.State,
                message.CustomerId);

            _customerRepository.AddAddress(address);

            return await PersistDataAsync(_customerRepository.UnitOfWork);
        }
    }
}