using GamblerX.Application;
using GamblerX.Infrastructure;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using GamblerX.API.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using GamblerX.API.Errors;
using GamblerX.API.Middleware;
using Microsoft.AspNetCore.Diagnostics;
using GamblerX.Application.Common.Interfaces.Persistence;
using GamblerX.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;


var builder = WebApplication.CreateBuilder(args);
{
    // Load configuration from appsettings.json
    var config = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

    // Get the connection string from configuration
    var connectionString = config.GetConnectionString("MyDatabaseConnection");
    
    
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-special-strong-256-bit-secret-key"))
            };
        });

    // Error handler 1
    //builder.Services.AddControllers();

    // Error handler 2
    builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

    // Error handler 3
   // builder.Services.AddSingleton<ProblemDetailsFactory, GamblerXProblemDetailsFactory>();


    builder.Services.AddDbContext<MyDbContext>(options =>
    {
        options.UseSqlServer(connectionString); // Replace with the appropriate database provider
    });

    // Register your repository as a service
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IBettingRepository, BettingRepository>();
}

var app = builder.Build();
{
    // Error handler 1
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    
    // Error handler 2
    app.UseExceptionHandler("/error");

    // Error handler 3
    // app.Map("/error", (HttpContext httpContext) =>
    // {
    //     Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    //     return Results.Problem();
    // });
    
    app.UseHttpsRedirection();

    app.UseAuthentication(); // Include authentication middleware

    app.UseAuthorization(); // Configure role-based authorization

    app.MapControllers();

    app.Run();
}




