using GamblerX.Domain.Entities;

namespace GamblerX.Application.Common.Interfaces.Persistence;


public interface IUserRepository
{
    User? GetUserByEmail(string email);
    User?   GetUserByUserName(string username);
    //User? GetUserById(Guid id);
    Task<User?> GetUserById(Guid id);
    void Add(User user);
}