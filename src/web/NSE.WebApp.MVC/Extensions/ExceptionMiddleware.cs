using Refit;
using System.Net;

namespace NSE.WebApp.MVC.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomHttpResquestException ex)
            {
                HandleRequestException(context, ex.StatusCode);
            }
            catch (ValidationApiException ex)
            {
                HandleRequestException(context, ex.StatusCode);
            }
            catch (ApiException ex)
            {
                HandleRequestException(context, ex.StatusCode);
            }
        }

        private static void HandleRequestException(HttpContext context, HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
                return;
            }

            context.Response.StatusCode = (int)statusCode;
        }
    }
}
