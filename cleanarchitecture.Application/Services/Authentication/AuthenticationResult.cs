using cleanarchitecture.Domain.Entities;
namespace cleanarchitecture.Application.Services;

public record AuthenticationResult(
    User user,
    string Token
);