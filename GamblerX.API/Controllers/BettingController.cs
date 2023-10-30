using System.Net.Cache;
using System.Security.Claims;
using GamblerX.Application.Services.Authentication;
using GamblerX.Application.Services.Persistence;
using GamblerX.Contracts.Authentication;
using GamblerX.Contracts.Persistence;
using GamblerX.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamblerX.API.Controllers;



[Route("betting")]
[ApiController]
[Authorize]
public class BettingController : ControllerBase
{
    private readonly IBettingService _bettingService;
  
    public BettingController(IBettingService bettingService)
    {
        _bettingService = bettingService;
    }


    [HttpPost("register-event")]
    public async Task<IActionResult> RegisterEvent(BettingRequest request)
    {
        //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;  // gets the logged in user's Id
        var betResult = await _bettingService.AddBettingAsync(new Betting
        {
            EventName = request.EventName,
            EventTime = request.EventTime
        });

        // map result to data contracted for this kind of response
        var response = new BettingResponse(
            betResult.Id,
            betResult.EventName,
            betResult.EventTime);

        return Ok(response);
    }
}