using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalogService _catalogService;

    public CatalogController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    [HttpGet]
    [Route("")]
    [Route("showcase")]
    public async Task<IActionResult> Index(
        [FromQuery] int ps = 8,
        [FromQuery] int page = 1,
        [FromQuery] string q = null)
    {
        var products = await _catalogService.GetAllAsync(ps, page, q);
        ViewBag.Search = q;
        return View(products);
    }

    [HttpGet]
    [Route("product-detail/{id:guid}")]
    public async Task<IActionResult> ProductDetail(Guid id)
    {
        return View(await _catalogService.GetByIdAsync(id));
    }
}
