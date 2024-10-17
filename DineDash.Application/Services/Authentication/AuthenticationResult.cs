using DineDash.Domain.Entities;

namespace DineDash.Application.Services.Authentication;

public record AuthenticationResult(User User, string Token);
