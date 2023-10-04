namespace GamblerX.Contracts.Authentication;

// Response when a user Login or Register
// public record AuthenticationResponse(
//     Guid Id,
//     string FirstName,
//     string LastName,
//     string Email,
//     string Token);


public class AuthenticationResponse
{
    public Guid Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Token { get; init; }
}