using GamblerX.Domain.Entities;

namespace GamblerX.Application.Common.Interfaces.Persistence;


public interface IUserRepository
{
    User? GetUserByEmail(string email);
    User? GetUserByUserName(string username);
    void Add(User user);
}