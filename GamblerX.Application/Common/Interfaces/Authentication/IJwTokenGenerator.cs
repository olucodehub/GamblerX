using GamblerX.Domain.Entities;

namespace GamblerX.Application.Common.Interfaces.Authentication;


public interface IJwTokenGenerator
{
    string GenerateToken(User user);
}