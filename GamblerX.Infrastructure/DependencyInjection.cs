using GamblerX.Application.Common.Interfaces.Authentication;
using GamblerX.Application.Common.Interfaces.Services;
using GamblerX.Infrastructure.Authentication;
using GamblerX.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GamblerX.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}