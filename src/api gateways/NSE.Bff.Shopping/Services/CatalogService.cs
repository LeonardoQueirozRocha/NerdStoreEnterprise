using Microsoft.Extensions.Options;
using NSE.Bff.Shopping.Extensions;
using NSE.Bff.Shopping.Models;
using NSE.Bff.Shopping.Services.Base;
using NSE.Bff.Shopping.Services.Interfaces;

namespace NSE.Bff.Shopping.Services
{
    public class CatalogService : BaseService, ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogUrl);
        }

        public async Task<ProductItemDTO> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"catalog/products/{id}");

            HandleResponseErrors(response);

            return await DeserializeResponseObject<ProductItemDTO>(response);
        }

        public async Task<IEnumerable<ProductItemDTO>> GetItemsAsync(IEnumerable<Guid> ids)
        {
            var idsRequest = string.Join(",", ids);
            var response = await _httpClient.GetAsync($"/catalog/products/list/{idsRequest}");

            HandleResponseErrors(response);

            return await DeserializeResponseObject<IEnumerable<ProductItemDTO>>(response);
        }
    }
}
