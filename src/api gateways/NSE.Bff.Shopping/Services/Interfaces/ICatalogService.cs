using NSE.Bff.Shopping.Models;

namespace NSE.Bff.Shopping.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<ProductItemDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductItemDTO>> GetItemsAsync(IEnumerable<Guid> ids);
    }
}
