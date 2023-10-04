using GamblerX.Application.Services.Authentication;
using GamblerX.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GamblerX.API.Controllers;


[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
  
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
  
  
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName ?? string.Empty, 
            request.LastName ?? string.Empty,  
            request.Email ?? string.Empty,     
            request.Password ?? string.Empty   
        );


        // map result to data contracted for this kind of response
                var response = new AuthenticationResponse
                {
                    Id = authResult.User.Id,
                    FirstName = authResult.User.FirstName,
                    LastName = authResult.User.LastName,
                    Email = authResult.User.Email,
                    Token = authResult.Token
                };
                
                return Ok(response);
    }
    

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
            var authResult = _authenticationService.Login(
            string.IsNullOrEmpty(request.Email) ? string.Empty : request.Email, 
            string.IsNullOrEmpty(request.Password) ? string.Empty : request.Password);

        var response = new AuthenticationResponse
        {
            Id = authResult.User.Id,
            FirstName = authResult.User.FirstName,
            LastName = authResult.User.LastName,
            Email = authResult.User.Email,
            Token = authResult.Token
        };


        return Ok(response);
    }
}