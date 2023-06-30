using Microsoft.Extensions.Options;
using NSE.Bff.Shopping.Extensions;
using NSE.Bff.Shopping.Services.Base;
using NSE.Bff.Shopping.Services.Interfaces;

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
    }
}
