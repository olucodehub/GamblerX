using GamblerX.Application.Common.Interfaces.Authentication;

namespace GamblerX.Application.Services.Authentication;


public class AuthenticationService : IAuthenticationService
{
   private readonly IJwTokenGenerator _jwTokenGenerator;

   public AuthenticationService(IJwTokenGenerator jwTokenGenerator)
    {
        _jwTokenGenerator = jwTokenGenerator;
    }
   
   
   
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exist

        // Create user (Generate unique ID)

        // Create JWT token
        Guid userId = Guid.NewGuid();

        var token = _jwTokenGenerator.GenerateToken(userId, firstName, lastName);
        
        return new AuthenticationResult(
            Guid.NewGuid(), 
            firstName, 
            lastName,
            email, 
            token);
    }

    
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "firstName", 
            "lastName",
            email, 
            "token");
    }
}