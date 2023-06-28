using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models.Error;

namespace NSE.WebApp.MVC.Controllers.Base
{
    public abstract class MainController : Controller
    {
        protected bool HasResponseErrors(ResponseResult response)
        {
            if (response != null && response.Errors.Messages.Any())
            {
                foreach (var message in response.Errors.Messages)
                {
                    ModelState.AddModelError(string.Empty, message);
                }

                return true;
            }

            return false;
        }

        protected void AddValidationError(string message) => ModelState.AddModelError(string.Empty, message);

        protected bool IsValid() => ModelState.ErrorCount == 0;
    }
}
