using DineDash.Domain.Entities;

namespace DineDash.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
