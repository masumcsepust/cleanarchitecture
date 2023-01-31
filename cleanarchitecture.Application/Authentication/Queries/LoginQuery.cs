
using cleanarchitecture.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace cleanarchitecture.Application.Authentication.Queries;

public record LoginQuery(
    string Email,
    string Password
): IRequest<ErrorOr<AuthenticationResult>>;