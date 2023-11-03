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
        var betResult = await _bettingService.AddBettingEvent(new Betting
        {
            EventName = request.EventName,
            EventTime = request.EventTime,
            EventImageUrl = request.EventImageUrl
        });

        // map result to data contracted for this kind of response
        var response = new BettingResponse(
            betResult.Id,
            betResult.EventName,
            betResult.EventTime);

        return Ok(response);
    }

    [HttpPut("update-event/{id}")]
    public async Task<IActionResult> UpdateEvent(Guid id, [FromBody] BettingUpdateRequest updateRequest)
    {
        var updatedBetting = new Betting
        {
            Id = id,
            EventName = updateRequest.EventName,
            EventTime = updateRequest.EventTime,
            EventImageUrl = updateRequest.EventImageUrl
        };

        var result = await _bettingService.UpdateBettingEvent(id, updatedBetting);

        if (result == null)
        {
             return NotFound("Betting event not found"); // Return 404 Not Found if the betting event with the given ID does not exist
        }

        return Ok(result); // Return the updated betting event
    }

    [HttpDelete("delete-event/{id}")]
    public async Task<IActionResult> DeleteEvent(Guid id)
    {
        var result = await _bettingService.DeleteBettingEvent(id);

        if (!result)
        {
            return NotFound("Betting event not found");
        }

        return NoContent(); // Return 204 No Content to indicate successful deletion
    }

    [HttpPost("place-bet")]
    public async Task<IActionResult> PlaceBet(BettorRequest request)
    {
        var userclaim = User.FindFirst(ClaimTypes.NameIdentifier);  
        if (userclaim == null)
        {
            return NotFound("User not found");
        }

        var userid = userclaim.Value;

        var result = await _bettingService.PlaceBet(new Bettor
        {
            UserId = Guid.Parse(userid),
            BettingId = request.BettingId,
            AmountBet = request.AmountBet,
            TeamSelected = request.TeamSelected
        });
        return Ok(result);
    }
}