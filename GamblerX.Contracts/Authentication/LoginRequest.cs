namespace GamblerX.Contracts.Authentication;

// public record LoginRequest(
//     string Email,
//     string Password);

public class LoginRequest
{
  public string? Email { get; init; }
  public string? Password { get; init; }
}