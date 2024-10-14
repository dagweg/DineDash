namespace DineDash.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, "login-token");
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, "registration-token");
    }
}
