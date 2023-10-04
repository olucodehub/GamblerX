
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using GamblerX.Contracts.Bet;
using Microsoft.AspNetCore.Mvc;

namespace GamblerX.API.Controllers;

[Route("bet")]
[ApiController]
[Authorize]
public class GambleController : ControllerBase
{
    private static readonly Random random = new Random();
    private int playerAccount = 10000;

   
    [HttpPost("place-bet")]
    public ActionResult<BetResult> PlaceBet([FromBody] BetRequest betRequest)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;  // gets the logged in user's Id
       
        // Check invalid  user entry
        if (betRequest.Points <= 0 || betRequest.Points > playerAccount || betRequest.Number < 0 || betRequest.Number > 9)
            return BadRequest("Invalid bet.");

        int randomNumber = random.Next(10);
        int winnings = 0;

        if (betRequest.Number == randomNumber)
        {
            winnings = betRequest.Points * 9;
            playerAccount += winnings;
            var response =  new BetResult
            {
                Account = playerAccount,
                Status = "won",
                Answer = randomNumber,
                Points = winnings
            };
            return Ok(response);
        }
        else
        {
            playerAccount -= betRequest.Points;
            var response = new BetResult
            {
                Account = playerAccount,
                Status = "lost",
                Answer = randomNumber,
                Points = -betRequest.Points
            };
            return Ok(response);
        }
    }
}
