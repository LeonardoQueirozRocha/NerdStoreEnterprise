using NSE.Catalog.API.Models;
using NSE.Core.Data;

namespace NSE.Catalog.API.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);

        void Add(Product product);
        void Update(Product product);
    }
}
