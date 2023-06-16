using EasyNetQ;
using FluentValidation.Results;
using NSE.Core.Mediator;
using NSE.Core.Messages.Integrations;
using NSE.Customers.API.Application.Commands;

namespace NSE.Customers.API.Services
{
    public class CustomerRegisterIntegrationHandler : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private IBus _bus;

        public CustomerRegisterIntegrationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            _bus.Rpc.RespondAsync<RegisteredUserIntegrationEvent, ResponseMessage>(async request 
                => new ResponseMessage(await RegisterCustomerAsync(request)));

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegisterCustomerAsync(RegisteredUserIntegrationEvent message)
        {
            ValidationResult success;
            var customerCommand = new CustomerRegisterCommand(message.Id, message.Name, message.Email, message.Cpf);

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                success = await mediator.SendCommandAsync(customerCommand);
            }

            return success;
        }
    }
}
