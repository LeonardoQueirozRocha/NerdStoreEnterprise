using Dapper;
using Microsoft.EntityFrameworkCore;
using NSE.Catalog.API.Data.Queries;
using NSE.Catalog.API.Data.Repositories.Interfaces;
using NSE.Catalog.API.Models;
using NSE.Core.Data;
using System.Data.Common;

namespace NSE.Catalog.API.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogContext _context;

    public ProductRepository(CatalogContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public DbConnection GetConnection() => _context.Database.GetDbConnection();

    public async Task<PagedResult<Product>> GetAllAsync(int pageSize, int pageIndex, string query = null)
    {
        var sql = SqlQueries.GetPagedProductsQuery(pageSize, pageIndex, query);
        var multi = await GetConnection().QueryMultipleAsync(sql, new { Name = query });
        var products = multi.Read<Product>();
        var total = multi.Read<int>().FirstOrDefault();

        return new PagedResult<Product>
        {
            List = products,
            TotalResults = total,
            PageIndex = pageIndex,
            PageSize = pageSize,
            Query = query
        };
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<List<Product>> GetProductsByIdAsync(string ids)
    {
        var idsGuid = ids
            .Split(',')
                .Select(id => (Ok: Guid.TryParse(id, out var x), Value: x));

        if (!idsGuid.All(nid => nid.Ok)) return new List<Product>();

        var idsValue = idsGuid.Select(id => id.Value);

        return await _context.Products
            .AsNoTracking()
                .Where(p => idsValue.Contains(p.Id) && p.Active)
                    .ToListAsync();
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}