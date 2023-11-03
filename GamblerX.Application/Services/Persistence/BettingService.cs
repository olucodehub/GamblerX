using System.Collections.Generic;
using GamblerX.Application.Common.Interfaces.Persistence;
using GamblerX.Application.Common.Interfaces.Services;
using GamblerX.Domain.Entities;

namespace GamblerX.Application.Services.Persistence;

public class BettingService : IBettingService
{
    private readonly IBettingRepository _bettingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public BettingService(IBettingRepository bettingRepository, IUserRepository userRepository, IDateTimeProvider dateTimeProvider)
    {
        _bettingRepository = bettingRepository;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Betting> AddBettingEvent(Betting betting)
    {
        return await _bettingRepository.AddBettingEventAsync(betting);
    }

    public async Task<Betting> UpdateBettingEvent(Guid id, Betting updatedBetting)
    {    
        return await _bettingRepository.UpdateBettingEventAsync(id, updatedBetting) ?? throw new Exception("Could not update, Bet was not found !");
    }

    public async Task<bool> DeleteBettingEvent(Guid id)
    {
        return await _bettingRepository.DeleteBettingEventAsync(id);
    }

    public async Task<Bettor> PlaceBet(Bettor bettor)
    {
        // check if the Betting id exists
        var betEvent = await _bettingRepository.GetBettingEventAsync(bettor.BettingId) ?? throw new Exception("Could not Place Bet, Event was not found !");

        // Calculate the time difference and check if is greater than 60 minutes
        TimeSpan timeDifference = betEvent.EventTime - _dateTimeProvider.UtcNow;
       
        if (timeDifference.TotalMinutes <= 60)
        {
            throw new Exception("Time to place bet has lapsed !");
        }
       
         // check if the user is allowed to bet
        var isbetProcessed = await ProcessUserBet(bettor);

        if (!isbetProcessed)
        {
            // Handle the case where the user is not allowed to bet.
            //return new BettingResult { Status = BettingStatus.NotAllowed };
            throw new Exception("User is not allowed to bet !");
        }

        return await _bettingRepository.AddBettorAsync(bettor);
    }

    public async Task<bool> ProcessUserBet(Bettor bettor)
    {
        // Check if the user exists
        var user = await _userRepository.GetUserById(bettor.UserId);

        if (user == null)
        {
            return false; // User does not exist
        }

        // Check if the user has a balance greater than 0
        if (user.Balance <= 0)
        {
            return false; // User's has no balance
        }

        if(bettor.AmountBet > user.Balance)
        {
            return false; // User's balance is not sufficient for the bet
        }

        if(bettor.TeamSelected != 1 || bettor.TeamSelected != 2)
        {
            return false; // Ensure user team selected is either 1 for Team/Player 1 or 2 for Team/Player 2
        }

        await _bettingRepository.UpdateUserBalanceAsync(user, bettor.AmountBet);

        // User is allowed to bet
        return true;
    }
}
