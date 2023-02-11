using NSE.WebApp.MVC.Extensions;
using System.Net;

namespace NSE.WebApp.MVC.Services.Base
{
    public abstract class BaseService
    {
        protected bool HandleResponseErrors(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                    throw new CustomHttpResquestException(response.StatusCode);

                case HttpStatusCode.BadRequest:
                    return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
