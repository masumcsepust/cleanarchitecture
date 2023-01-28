using cleanarchitecture.Application.Common.Interfaces.Persistence;
using cleanarchitecture.Domain.Entities;
namespace cleanarchitecture.Infrastructure.Persistence;

public class UserRepository: IUserRepository
{
    public static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User GetUserByEmail(string email)
    {
        var user = _users.SingleOrDefault(u => u.Email == email);
        return user;
    }
}