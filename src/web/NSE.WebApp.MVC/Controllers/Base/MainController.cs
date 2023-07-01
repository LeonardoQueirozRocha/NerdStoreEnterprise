using Microsoft.AspNetCore.Mvc;
using NSE.Core.Communication;

namespace NSE.WebApp.MVC.Controllers.Base
{
    public abstract class MainController : Controller
    {
        protected bool HasResponseErrors(ResponseResult response)
        {
            if (response != null && response.Errors.Messages.Any())
            {
                response.Errors.Messages.ForEach(message => ModelState.AddModelError(string.Empty, message));

                return true;
            }

            return false;
        }

        protected void AddValidationError(string message) => ModelState.AddModelError(string.Empty, message);

        protected bool IsValid() => ModelState.ErrorCount == 0;
    }
}
