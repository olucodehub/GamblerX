using GamblerX.Application.Common.Interfaces.Authentication;
using GamblerX.Application.Common.Interfaces.Persistence;
using GamblerX.Application.Common.Interfaces.Services;
using GamblerX.Infrastructure.Authentication;
using GamblerX.Infrastructure.Persistence;
using GamblerX.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GamblerX.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBettingRepository, BettingRepository>();

        return services;
    }
}