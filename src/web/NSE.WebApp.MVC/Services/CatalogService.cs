using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models.Catalog;
using NSE.WebApp.MVC.Services.Base;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Services;

public class CatalogService : BaseService, ICatalogService
{
    private readonly HttpClient _httpClient;

    public CatalogService(HttpClient httpClient, IOptions<AppSettings> settings)
    {
        httpClient.BaseAddress = new Uri(settings.Value.CatalogUrl);
        _httpClient = httpClient;
    }

    public async Task<PagedViewModel<ProductViewModel>> GetAllAsync(int pageSize, int pageIndex, string query = null)
    {
        var response = await _httpClient.GetAsync($"/catalog/products/?ps={pageSize}&page={pageIndex}&q={query}");

        HandleResponseErrors(response);

        return await DeserializeResponseObject<PagedViewModel<ProductViewModel>>(response);
    }

    public async Task<ProductViewModel> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"/catalog/products/{id}");

        HandleResponseErrors(response);

        return await DeserializeResponseObject<ProductViewModel>(response);
    }
}
