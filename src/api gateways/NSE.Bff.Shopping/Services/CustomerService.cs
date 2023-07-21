using Microsoft.Extensions.Options;
using NSE.Bff.Shopping.Extensions;
using NSE.Bff.Shopping.Models;
using NSE.Bff.Shopping.Services.Base;
using NSE.Bff.Shopping.Services.Interfaces;
using System.Net;

namespace NSE.Bff.Shopping.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CustomerUrl);
        }

        public async Task<AddressDTO> GetAddressAsync()
        {
            var response = await _httpClient.GetAsync("/custoemrs/addresses/");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            HandleResponseErrors(response);

            return await DeserializeResponseObject<AddressDTO>(response);
        }
    }
}
