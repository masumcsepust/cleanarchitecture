using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using cleanarchitecture.Application.Common.Errors;

namespace cleanarchitecture.API.Controllers;
public class ErrorsController: ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
        var (statusCode, message) = exception switch
        {
            IServiceException serviceExceptions => ((int)serviceExceptions.StatusCode, serviceExceptions.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "an unexpected error occurred")
        };
        // return Problem(title: exception.Message, statusCode: 400);
        return Problem(statusCode: statusCode, title: message);
    }
}