using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace cleanarchitecture.API.Filters;

public class ErrorHandlingFilterAttribute: ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails 
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred while processing your request",
            Status = (int)HttpStatusCode.InternalServerError
        };

        context.Result = new ObjectResult(problemDetails);

        // context.Result = new ObjectResult(new { error = "An error occurred while processing your request"})
        // {
        //     StatusCode = 500
        // };
        // base.OnException(context);

        context.ExceptionHandled = true;
    }
}