namespace GamblerX.Contracts.Authentication;
// public class RegisterRequest(
//     string FirstName,
//     string LastName,
//     string Email,
//     string Password);


public class RegisterRequest
{
  public string? FirstName { get; set; }
  public string? LastName { get; init; }
  public string? Email { get; init; }
  public string? Password { get; init; }
}