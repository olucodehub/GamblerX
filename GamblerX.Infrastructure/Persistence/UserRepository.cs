using System;
using GamblerX.Application.Common.Interfaces.Persistence;
using GamblerX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GamblerX.Infrastructure.Persistence;


public class UserRepository : IUserRepository
{    private readonly MyDbContext _context;

    public UserRepository(MyDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
       return _context.Users.SingleOrDefault(x => x.Email == email);
    }

    public User? GetUserByUserName(string username)
    {
        return _context.Users.SingleOrDefault(x => x.UserName == username);
    }

    public async Task<User?> GetUserById(Guid id)
    {
       return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
    }
}