using cleanarchitecture.Domain.Entities;

namespace cleanarchitecture.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User user,
    string Token
);