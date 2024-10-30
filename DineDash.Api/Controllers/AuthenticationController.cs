using DineDash.Application.Services.Authentication;
using DineDash.Contracts.Authentication;
using FluentResults;
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
        Result<AuthenticationResult> result = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        if (result.IsSuccess)
        {
            var response = new AuthenticationResponse(
                result.Value.User.UserId,
                result.Value.User.FirstName,
                result.Value.User.LastName,
                result.Value.User.Email,
                result.Value.Token
            );

            return Ok(response);
        }

        ObjectResult problem = Problem(
            statusCode: StatusCodes.Status500InternalServerError,
            detail: "An error occurred"
        );

        if (result.Errors.Any())
        {
            problem = Problem(
                statusCode: StatusCodes.Status409Conflict,
                detail: result.Errors.First().Message
            );
        }

        return problem;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        Result<AuthenticationResult> result = _authenticationService.Login(
            request.Email,
            request.Password
        );

        if (result.IsSuccess)
        {
            var response = new AuthenticationResponse(
                result.Value.User.UserId,
                result.Value.User.FirstName,
                result.Value.User.LastName,
                result.Value.User.Email,
                result.Value.Token
            );

            return Ok(response);
        }

        ObjectResult problem = Problem(
            statusCode: StatusCodes.Status500InternalServerError,
            detail: "An error occurred"
        );

        if (result.Errors.Any())
        {
            problem = Problem(
                statusCode: StatusCodes.Status409Conflict,
                detail: result.Errors.First().Message
            );
        }

        return problem;
    }
}
