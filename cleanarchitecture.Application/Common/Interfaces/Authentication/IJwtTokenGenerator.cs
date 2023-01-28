using cleanarchitecture.Domain.Entities;

namespace cleanarchitecture.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}