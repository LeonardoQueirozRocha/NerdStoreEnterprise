using NSE.WebApp.MVC.Models.Catalog;

namespace NSE.WebApp.MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<PagedViewModel<ProductViewModel>> GetAllAsync(int pageSize, int pageIndex, string query = null);
    Task<ProductViewModel> GetByIdAsync(Guid id);
}