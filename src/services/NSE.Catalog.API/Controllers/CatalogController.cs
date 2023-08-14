using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalog.API.Data.Repositories.Interfaces;
using NSE.Catalog.API.Models;
using NSE.WebApi.Core.Controllers;

namespace NSE.Catalog.API.Controllers;

[Authorize]
[Route("catalog/products")]
public class CatalogController : MainController
{
    private readonly IProductRepository _productRepository;

    public CatalogController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<PagedResult<Product>> Index(
        [FromQuery] int ps = 8,
        [FromQuery] int page = 1,
        [FromQuery] string q = null)
    {
        return await _productRepository.GetAllAsync(ps, page, q);
    }

    [HttpGet("{id:guid}")]
    public async Task<Product> ProductDetail(Guid id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    [HttpGet("list/{ids}")]
    public async Task<IEnumerable<Product>> GetProductsById(string ids)
    {
        return await _productRepository.GetProductsByIdAsync(ids);
    }
}
