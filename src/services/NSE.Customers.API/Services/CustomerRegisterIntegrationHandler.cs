using FluentValidation.Results;
using NSE.Core.Mediator;
using NSE.Core.Messages.Integrations;
using NSE.Customers.API.Application.Commands;
using NSE.MessageBus.Interfaces;

namespace NSE.Customers.API.Services
{
    public class CustomerRegisterIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CustomerRegisterIntegrationHandler(
            IMessageBus bus,
            IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private async Task<ResponseMessage> RegisterCustomerAsync(RegisteredUserIntegrationEvent message)
        {
            ValidationResult result;
            var customerCommand = new CustomerRegisterCommand(message.Id, message.Name, message.Email, message.Cpf);

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                result = await mediator.SendCommandAsync(customerCommand);
            }

            return new ResponseMessage(result);
        }

        private void SetResponder()
        {
            _bus.RespondAsync<RegisteredUserIntegrationEvent, ResponseMessage>(async request => await RegisterCustomerAsync(request));
            _bus.AdvancedBus.Connected += OnConnect;
        }

        private void OnConnect(object sender, EventArgs e) => SetResponder();
    }
}
