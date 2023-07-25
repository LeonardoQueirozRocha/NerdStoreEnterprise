using Microsoft.Extensions.Options;
using NSE.Bff.Shopping.Extensions;
using NSE.Bff.Shopping.Models;
using NSE.Bff.Shopping.Services.Base;
using NSE.Bff.Shopping.Services.Interfaces;
using NSE.Core.Communication;
using System.Net;

namespace NSE.Bff.Shopping.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.OrderUrl);
        }

        public async Task<ResponseResult> ConcludeOrderAsync(OrderDTO order)
        {
            var orderContent = GetContent(order);
            var response = await _httpClient.PostAsync("/orders/", orderContent);

            if (!HandleResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return Ok();
        }

        public async Task<OrderDTO> GetLastOrderAsync()
        {
            var response = await _httpClient.GetAsync("/orders/last/");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            return await DeserializeResponseObject<OrderDTO>(response);
        }

        public async Task<IEnumerable<OrderDTO>> GetListByCustomerIdAsync()
        {
            var response = await _httpClient.GetAsync("/orders/customer-list/");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            HandleResponseErrors(response);

            return await DeserializeResponseObject<IEnumerable<OrderDTO>>(response);
        }

        public async Task<VoucherDTO> GetVoucherByCodeAsync(string code)
        {
            var response = await _httpClient.GetAsync($"/vouchers/{code}/");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            HandleResponseErrors(response);

            return await DeserializeResponseObject<VoucherDTO>(response);
        }
    }
}
