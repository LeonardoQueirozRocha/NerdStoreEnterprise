using NSE.Core.Communication;
using NSE.WebApp.MVC.Models.Customer;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<AddressViewModel> GetAddressAsync();
        Task<ResponseResult> AddAddressAsync(AddressViewModel address);
    }
}
