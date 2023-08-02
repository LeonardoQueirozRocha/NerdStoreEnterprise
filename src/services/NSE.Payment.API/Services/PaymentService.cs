using FluentValidation.Results;
using NSE.Core.Messages.Integrations;
using NSE.Payment.API.Facade.Interfaces;
using NSE.Payment.API.Models.Enums;
using NSE.Payment.API.Models.Interfaces;
using NSE.Payment.API.Services.Interfaces;

namespace NSE.Payment.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentFacade _paymentFacade;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(
            IPaymentFacade paymentFacade,
            IPaymentRepository paymentRepository)
        {
            _paymentFacade = paymentFacade;
            _paymentRepository = paymentRepository;
        }

        public async Task<ResponseMessage> AuthorizePaymentAsync(Models.Payment payment)
        {
            var transaction = await _paymentFacade.AuthorizePaymentAsync(payment);
            var validationResult = new ValidationResult();

            if (transaction.TransactionStatus != TransactionStatus.Authorized)
            {
                validationResult.Errors.Add(new ValidationFailure("Payment", "Pagamento recusado, entre em contato com a sua operadora de cartão"));
                return new ResponseMessage(validationResult);
            }

            payment.AddTransaction(transaction);
            _paymentRepository.AddPayment(payment);

            if (!await _paymentRepository.UnitOfWork.Commit())
            {
                validationResult.Errors.Add(new ValidationFailure("Payment", "Houve um erro ao realizar o pagamento."));

                //TODO: Comunicar com o gateway para realizar o estorno.

                return new ResponseMessage(validationResult);
            }

            return new ResponseMessage(validationResult);
        }
    }
}
