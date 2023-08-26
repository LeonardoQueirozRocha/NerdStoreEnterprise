using Grpc.Core;
using NSE.WebApp.MVC.Services.Interfaces;
using Polly.CircuitBreaker;
using System.Net;

namespace NSE.WebApp.MVC.Extensions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Dictionary<StatusCode, HttpStatusCode> MapProtoStatusCodeToHttpStatusCode;
    private static IAuthService _authService;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;

        MapProtoStatusCodeToHttpStatusCode = new()
        {
            { StatusCode.Internal, HttpStatusCode.BadRequest },
            { StatusCode.Unauthenticated, HttpStatusCode.Unauthorized },
            { StatusCode.PermissionDenied, HttpStatusCode.Forbidden },
            { StatusCode.Unimplemented, HttpStatusCode.NotFound }
        };
    }

    public async Task InvokeAsync(HttpContext context, IAuthService authService)
    {
        _authService = authService;

        try
        {
            await _next(context);
        }
        catch (CustomHttpResquestException ex)
        {
            HandleRequestException(context, ex.StatusCode);
        }
        catch (BrokenCircuitException)
        {
            HandleCircuitBreakerExceptionAsync(context);
        }
        catch (RpcException ex)
        {
            HandleRpcException(context, ex.StatusCode);
        }
    }

    private static void HandleRequestException(HttpContext context, HttpStatusCode statusCode)
    {
        if (statusCode == HttpStatusCode.Unauthorized)
        {
            if (_authService.IsTokenExpired() && _authService.IsRefreshTokenValid().Result)
            {
                context.Response.Redirect(context.Request.Path);
                return;
            }

            _authService.LogoutAsync().Wait();
            context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
            return;
        }

        context.Response.StatusCode = (int)statusCode;
    }

    private static void HandleCircuitBreakerExceptionAsync(HttpContext context)
    {
        context.Response.Redirect("/unavailable-system");
    }

    private void HandleRpcException(HttpContext context, StatusCode protoStatusCode)
    {
        if (!MapProtoStatusCodeToHttpStatusCode.TryGetValue(protoStatusCode, out var statusCode))
            statusCode = HttpStatusCode.InternalServerError;

        HandleRequestException(context, statusCode);
    }
}
