using GamblerX.Application.Services.Authentication;
using GamblerX.Application.Services.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace GamblerX.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IBettingService, BettingService>();

        return services;
    }
}