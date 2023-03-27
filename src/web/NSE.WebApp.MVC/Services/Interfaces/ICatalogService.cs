using NSE.WebApp.MVC.Models.Catalog;
using Refit;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<ProductViewModel>> GetAllAsync();
        Task<ProductViewModel> GetByIdAsync(Guid id);
    }

    public interface ICatalogServiceRefit
    {
        [Get("/catalog/products/")]
        Task<IEnumerable<ProductViewModel>> GetAllAsync();

        [Get("/catalog/products/{id}")]
        Task<ProductViewModel> GetByIdAsync(Guid id);
    }
}
