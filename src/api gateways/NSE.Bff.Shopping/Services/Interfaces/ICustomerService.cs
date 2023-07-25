using NSE.Bff.Shopping.Models;

namespace NSE.Bff.Shopping.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<AddressDTO> GetAddressAsync();
    }
}
