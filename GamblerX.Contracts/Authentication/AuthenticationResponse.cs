namespace GamblerX.Contracts.Authentication;

// Response when a user Login or Register
public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);