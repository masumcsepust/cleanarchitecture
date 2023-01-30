using cleanarchitecture.Application.Common.Errors;
using cleanarchitecture.Application.Services;
using cleanarchitecture.Application.Services.Authentication;
using cleanarchitecture.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace cleanarchitecture.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    //[ErrorHandlingFilterAttribute]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request) 
        {
            // var authResult = _authenticationService.Register(
            //     request.FirstName, 
            //     request.LastName, 
            //     request.Email, 
            //     request.Password
            // );
            
            // var response = new AuthenticationResponse(
            //     authResult.user.Id,
            //     authResult.user.FirstName,
            //     authResult.user.LastName,
            //     authResult.user.Email,
            //     authResult.Token
            // );

            OneOf<AuthenticationResult, DuplicateEmailError> registerResult = _authenticationService.Register(
                request.FirstName, 
                request.LastName, 
                request.Email, 
                request.Password
            );
            
            // if(registerResult.IsT0) 
            // {
            //     var authResult = registerResult.AsT0;
            //     var response = new AuthenticationResponse(
            //         authResult.user.Id,
            //         authResult.user.FirstName,
            //         authResult.user.LastName,
            //         authResult.user.Email,
            //         authResult.Token
            //     );
                
            //     return Ok(response);
            // }

            // return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists.");

            return registerResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                _ => Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists.")
            );
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
            );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request) 
        {
            var authResult = _authenticationService.Login(
                request.Email, 
                request.Password
                );
            var response = new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
            );

            return Ok(response);
        }
    }
}