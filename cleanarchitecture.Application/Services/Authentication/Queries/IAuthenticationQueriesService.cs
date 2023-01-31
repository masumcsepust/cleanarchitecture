using cleanarchitecture.Application.Common.Errors;
using cleanarchitecture.Application.Services.Authentication.Common;
using ErrorOr;
using FluentResults;

namespace cleanarchitecture.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueriesService
    {
        //Result<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);
        ErrorOr<AuthenticationResult> Login(string Email, string Password);
    }
}