using NSE.Core.Messages.Integrations;

namespace NSE.Payment.API.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<ResponseMessage> AuthorizePaymentAsync(Models.Payment payment);
    }
}
