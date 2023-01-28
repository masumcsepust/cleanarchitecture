using cleanarchitecture.Domain.Entities;

namespace cleanarchitecture.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User GetUserByEmail(string email);
    void Add(User user);
}