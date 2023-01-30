using cleanarchitecture.Application.Common.Errors;
using ErrorOr;
using FluentResults;

namespace cleanarchitecture.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        //Result<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);
        ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);
        ErrorOr<AuthenticationResult> Login(string Email, string Password);
    }
}