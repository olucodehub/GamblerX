using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamblerX.API.Filters;


//Global error handling that can be used on all controllers. Use the attribute on all controllers by definging it in the program.cs
//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

// Error handler 2
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        // You can specify more ProblemDetails properties Ex: Type, Detail, instance e.t.c.
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",  // uri to web page containing documentation to request/response semantics
            Title = "An error occured while processing your request",
            Status = (int)HttpStatusCode.InternalServerError
        };

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
    }
}