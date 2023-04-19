using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;

namespace NSE.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEventAsync<T>(T act) where T : Event
        {
            await _mediator.Publish(act);
        }

        public async Task<ValidationResult> SendCommandAsync<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
