using DineDash.Application.Services.Authentication;
using DineDash.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DineDash.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            result.User.UserId,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(
            result.User.UserId,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token
        );

        return Ok(response);
    }
}
