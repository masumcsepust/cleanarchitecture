
using cleanarchitecture.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace cleanarchitecture.Application.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
): IRequest<ErrorOr<AuthenticationResult>>;