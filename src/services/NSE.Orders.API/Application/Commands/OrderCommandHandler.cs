using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;

namespace NSE.Orders.API.Application.Commands
{
    public class OrderCommandHandler : CommandHandler, IRequestHandler<AddOrderCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(AddOrderCommand message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
