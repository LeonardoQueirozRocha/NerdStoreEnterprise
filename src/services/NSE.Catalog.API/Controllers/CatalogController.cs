using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalog.API.Data.Repositories.Interfaces;
using NSE.Catalog.API.Models;
using NSE.WebApi.Core.Identity;

namespace NSE.Catalog.API.Controllers
{
    [ApiController]
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        [HttpGet("catalog/products")]
        public async Task<IEnumerable<Product>> Index()
        {
            return await _productRepository.GetAllAsync();
        }

        [ClaimsAuthorize("Catalog", "Read")]
        [HttpGet("catalog/products/{id:guid}")]
        public async Task<Product> ProductDetail(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
