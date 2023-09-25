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
            //        //Get userId and bearer token 
            // var userId = User..GetNameIdentifierId();
            // var username = HttpContext.User.FindFirstValue("name");
            // var token = HttpContext.Request.Headers[HeaderNames.Authorization];
       
       
        var authResult = _authenticationService.Register(
            request.FirstName, 
            request.LastName,
            request.Email, 
            request.Password);

// map result to data contracted for this kind of response
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);


        return Ok(response);
    }
    

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
            var authResult = _authenticationService.Login(
            request.Email, 
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);


        return Ok(response);
    }
}