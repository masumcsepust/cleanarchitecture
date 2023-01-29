using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace cleanarchitecture.API.Controllers;

public class ErrorsController: ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
        return Problem(title: exception.Message, statusCode: 400);
    }
}