using cleanarchitecture.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using cleanarchitecture.Domain.Common.Errors;
using cleanarchitecture.Application.Services.Authentication.Common;
using MediatR;
using cleanarchitecture.Application.Authentication.Commands;
using cleanarchitecture.Application.Authentication.Queries;
using MapsterMapper;

namespace cleanarchitecture.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    //[ErrorHandlingFilterAttribute]
    public class AuthenticationController : ApiController
    {
        // private readonly IAuthenticationCommandService _authenticationCommandsService;
        // private readonly IAuthenticationQueriesService _authenticationQueriesService;

        // public AuthenticationController(IAuthenticationCommandService authenticationCommandsService,
        // IAuthenticationQueriesService authenticationQueriesService)
        // {
        //     _authenticationCommandsService = authenticationCommandsService;
        //     _authenticationQueriesService = authenticationQueriesService;
        // }

        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request) 
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

            // OneOf<AuthenticationResult, IError> registerResult = _authenticationService.Register(
            //     request.FirstName, 
            //     request.LastName, 
            //     request.Email, 
            //     request.Password
            // );
            
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

            // return registerResult.Match(
            //     authResult => Ok(MapAuthResult(authResult)),
            //     error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
            // );

            // Result<AuthenticationResult> registerResult = _authenticationService.Register(
            //     request.FirstName, 
            //     request.LastName, 
            //     request.Email, 
            //     request.Password
            // );

            // if(registerResult.IsSuccess) 
            //     return Ok(registerResult.Value);
            
            // var firstError = registerResult.Errors[0];

            // if(firstError is DuplicateEmailError)
            //     return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists");
            //return Problem();
            
            // ErrorOr<AuthenticationResult> registerResult = _authenticationCommandsService.Register(
            //     request.FirstName, 
            //     request.LastName, 
            //     request.Email, 
            //     request.Password
            // );

            // var command = new RegisterCommand(
            //     request.FirstName, 
            //     request.LastName, 
            //     request.Email, 
            //     request.Password
            // );

            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            // return authResult.Match(
            //     authResult => Ok(MapAuthResult(authResult)),
            //     errors => Problem(errors)
            // );
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
            );

        }

        public static AuthenticationResponse NewMethod(AuthenticationResult authResult) 
        {
            return new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
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
        public async Task<IActionResult> Login(LoginRequest request) 
        {
            // ErrorOr<AuthenticationResult> authResult = _authenticationQueriesService.Login(
            //     request.Email, 
            //     request.Password
            //     );


            // var response = new AuthenticationResponse(
            //     authResult.user.Id,
            //     authResult.user.FirstName,
            //     authResult.user.LastName,
            //     authResult.user.Email,
            //     authResult.Token
            // );
            // return authResult.MatchFirst(
            //     authResult => Ok(NewMethod(authResult)),
            //     firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
            // );
            //return Ok(response);
            // var query = new LoginQuery(request.Email, request.Password);
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            if(authResult.IsError && authResult.FirstError==Errors.Authentication.InvalidCredential)
                return 
                    Problem(
                        statusCode: StatusCodes.Status401Unauthorized, 
                        title: authResult.FirstError.Description
                    );

            // return authResult.Match(
            //     authResult => Ok(MapAuthResult(authResult)),
            //     errors => Problem(errors)
            // );

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
            );
        }
    }
}