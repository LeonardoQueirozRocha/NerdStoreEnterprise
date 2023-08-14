using NSE.Catalog.API.Models;
using NSE.Core.Data;
using System.Data.Common;

namespace NSE.Catalog.API.Data.Repositories.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    DbConnection GetConnection();
    Task<PagedResult<Product>> GetAllAsync(int pageSize, int pageIndex, string query = null);
    Task<Product> GetByIdAsync(Guid id);
    Task<List<Product>> GetProductsByIdAsync(string ids);

    void Add(Product product);
    void Update(Product product);
}
