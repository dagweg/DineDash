using DineDash.Application.Common.Interfaces.Authentication;
using DineDash.Application.Common.Interfaces.Persistence;
using DineDash.Application.Common.Interfaces.Services;
using DineDash.Application.Services.Authentication;
using DineDash.Infrastructure.Authentication;
using DineDash.Infrastructure.Persistence;
using DineDash.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DineDash.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
