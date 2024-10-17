using DineDash.Application.Common.Interfaces.Authentication;
using DineDash.Application.Common.Interfaces.Persistence;
using DineDash.Domain.Entities;

namespace DineDash.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
    )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        // Check if user exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User already exists");
        }

        // Create a user
        var user = new User
        {
            UserId = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Check if user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User does not exist");
        }

        if (user.Password != password)
            throw new Exception("Invalid password");

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
