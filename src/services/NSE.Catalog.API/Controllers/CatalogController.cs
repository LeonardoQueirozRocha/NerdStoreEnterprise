using Microsoft.AspNetCore.Mvc;
using NSE.Catalog.API.Data.Repositories.Interfaces;
using NSE.Catalog.API.Models;

namespace NSE.Catalog.API.Controllers
{
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("catalog/products")]
        public async Task<IEnumerable<Product>> Index()
        {
            return await _productRepository.GetAllAsync();
        }

        [HttpGet("catalog/products/{id:guid}")]
        public async Task<Product> ProdutoDetail(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
