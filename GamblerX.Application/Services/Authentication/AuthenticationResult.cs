using GamblerX.Domain.Entities;

namespace GamblerX.Application.Services.Authentication;


public record AuthenticationResult(
    User User,
    string Token);