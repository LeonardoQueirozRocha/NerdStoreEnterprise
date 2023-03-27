using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogServiceRefit _catalogService;

        public CatalogController(ICatalogServiceRefit catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        [Route("")]
        [Route("showcase")]
        public async Task<IActionResult> Index()
        {
            var products = await _catalogService.GetAllAsync();

            return View(products);
        }

        [HttpGet]
        [Route("product-detail/{id:guid}")]
        public async Task<IActionResult> ProductDetail(Guid id)
        {
            var product = await _catalogService.GetByIdAsync(id);

            return View(product);
        }
    }
}
