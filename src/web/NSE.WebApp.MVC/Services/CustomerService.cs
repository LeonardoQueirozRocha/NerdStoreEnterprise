using Microsoft.Extensions.Options;
using NSE.Core.Communication;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models.Customer;
using NSE.WebApp.MVC.Services.Base;
using NSE.WebApp.MVC.Services.Interfaces;
using System.Net;

namespace NSE.WebApp.MVC.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClientt, IOptions<AppSettings> settings)
        {
            _httpClient = httpClientt;
            _httpClient.BaseAddress = new Uri(settings.Value.CustomerUrl);
        }

        public async Task<AddressViewModel> GetAddressAsync()
        {
            var response = await _httpClient.GetAsync("/customers/addresses/");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            HandleResponseErrors(response);

            return await DeserializeResponseObject<AddressViewModel>(response);
        }

        public async Task<ResponseResult> AddAddressAsync(AddressViewModel address)
        {
            var addressContent = GetContent(address);
            var response = await _httpClient.PostAsync("/customers/addresses/", addressContent);

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }
    }
}
