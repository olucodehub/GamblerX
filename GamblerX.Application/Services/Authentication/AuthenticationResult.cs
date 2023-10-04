using GamblerX.Domain.Entities;

namespace GamblerX.Application.Services.Authentication;


// public record AuthenticationResult(
//     User User,
//     string Token);

public class AuthenticationResult
{
  public User? User { get; init; }
  public string? Token { get; init; }
}