using System.Net;
using System.Text.Json;

namespace GamblerX.API.Middleware;

// Error handler 1
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }   
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }        
    }

    //function that is called when there is an exception
    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError; //500 if unexpected
        var result = JsonSerializer.Serialize(new {error = "An error occured while processing your request"});
        context.Response.ContentType = "application.json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}