using NSE.Payment.API.Models;

namespace NSE.Payment.API.Facade.Interfaces
{
    public interface IPaymentFacade
    {
        Task<Transaction> AuthorizePaymentAsync(Models.Payment payment);
    }
}
