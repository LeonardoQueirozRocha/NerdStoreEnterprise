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
                HandleRequestException(context, ex);
            }
        }

        private static void HandleRequestException(HttpContext context, CustomHttpResquestException httpResquestException)
        {
            if (httpResquestException.StatusCode == HttpStatusCode.Unauthorized)
            {
                context.Response.Redirect("/login");
                return;
            }

            context.Response.StatusCode = (int)httpResquestException.StatusCode;
        }
    }
}
