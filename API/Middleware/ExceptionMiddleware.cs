using Domain.Exceptions;
using System.Net;

namespace API.Middleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (NotFoundException)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            httpContext.Response.ContentType = "text";
            await httpContext.Response.WriteAsync("Resource not found!");
        }
        catch (Exception)
        {
            await httpContext.Response.WriteAsync("Unhandled Exception");
        }
    }
}
