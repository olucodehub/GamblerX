using GamblerX.Application.Common.Interfaces.Authentication;
using GamblerX.Application.Common.Interfaces.Persistence;
using GamblerX.Domain.Entities;

namespace GamblerX.Application.Services.Authentication;


public class AuthenticationService : IAuthenticationService
{
   private readonly IJwTokenGenerator _jwTokenGenerator;
   private readonly IUserRepository _userRepository;

   public AuthenticationService(IJwTokenGenerator jwTokenGenerator, IUserRepository userRepository)
    {
        _jwTokenGenerator = jwTokenGenerator;
        _userRepository = userRepository;
    }
   
   
   
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Validate User does not exist
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User already exists");
        }

        // Create user (Generate unique ID) and Persist to DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);


        // Create JWT token
        var token = _jwTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token);
    }

    
    public AuthenticationResult Login(string email, string password)
    {
        // Validate the user exisits
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User does not exists");  // just for testing purpose, change later
        }

        // validate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid Password"); 
        }

        // Create JWT Token
        var token = _jwTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token);
    }
}