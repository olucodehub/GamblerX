namespace GamblerX.Application.Services.Authentication;


public interface IAuthenticationService
{
    AuthenticationResult Register(string userName,string email, string token);

    AuthenticationResult Login(string email, string password);

}