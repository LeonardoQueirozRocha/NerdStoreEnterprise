using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers.Base
{
    public abstract class MainController : Controller
    {
        protected bool HasResponseErrors(ResponseResult response)
        {
            if (response != null && response.Errors.Messages.Any())
            {
                return true;
            }

            return false;
        }
    }
}
