using GamblerX.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace GamblerX.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}