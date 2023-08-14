using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models.Catalog;

namespace NSE.WebApp.MVC.Extensions.ViewComponents;

public class PaginationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(IPagedList pagedModel)
    {
        return View(pagedModel);
    }
}
