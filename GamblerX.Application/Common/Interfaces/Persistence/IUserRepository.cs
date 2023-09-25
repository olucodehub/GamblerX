using GamblerX.Domain.Entities;

namespace GamblerX.Application.Common.Interfaces.Persistence;


public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}