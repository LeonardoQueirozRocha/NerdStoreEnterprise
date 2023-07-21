using NSE.Catalog.API.Models;
using NSE.Core.Data;

namespace NSE.Catalog.API.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<List<Product>> GetProductsByIdAsync(string ids);

        void Add(Product product);
        void Update(Product product);
    }
}
