using NSE.Core.Messages.Integrations;
using NSE.MessageBus.Interfaces;
using NSE.Payment.API.Models;
using NSE.Payment.API.Services.Interfaces;

namespace NSE.Payment.API.Services
{
    public class PaymentIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public PaymentIntegrationHandler(
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

        private void SetResponder()
        {
            _bus.RespondAsync<StartedOrderIntegrationEvent, ResponseMessage>(async request =>
            {
                return await AuthorizePaymentAsync(request);
            });
        }

        private async Task<ResponseMessage> AuthorizePaymentAsync(StartedOrderIntegrationEvent message)
        {
            ResponseMessage response;

            using (var scope = _serviceProvider.CreateScope())
            {
                var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();
                var payment = new Models.Payment
                {
                    OrderId = message.OrderId,
                    PaymentType = (PaymentType)message.PaymentType,
                    Value = message.Value,
                    CreditCard = new CreditCard(
                        message.CardName,
                        message.CardNumber,
                        message.CardExpirationDate,
                        message.CardCvv)
                };

                response = await paymentService.AuthorizePaymentAsync(payment);
            }

            return response;
        }
    }
}
