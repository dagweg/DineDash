using DineDash.Application.Common.Interfaces.Persistence;
using DineDash.Domain.Entities;

namespace DineDash.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        if (_users.Any(existingUser => existingUser.Email == user.Email))
        {
            throw new ArgumentException("A user with this email already exists.");
        }
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user => user.Email == email);
    }
}
