using GamblerX.Application.Common.Interfaces.Persistence;
using GamblerX.Application.Common.Interfaces.Services;
using GamblerX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GamblerX.Infrastructure.Persistence;


public class BettingRepository : IBettingRepository
{
    private readonly MyDbContext _context;

    public BettingRepository(MyDbContext context)
    {
        _context = context;
    }

    #region Betting Event

    public async Task<Betting> AddBettingEventAsync(Betting betting)
    {
        _context.Bettings.Add(betting);
        await _context.SaveChangesAsync();
        return betting;
    }

    public async Task<Betting?> GetBettingEventAsync(Guid id)  
    {
        var betEvent = await _context.Bettings.FindAsync(id);
        if (betEvent == null)
        {
            return null;
        }

        return betEvent;
    }

    public async Task<Betting?> UpdateBettingEventAsync(Guid id, Betting updatedBetting)  
    {
        var existingBetting = await _context.Bettings.FindAsync(id);
        if (existingBetting == null)
        {
            return null;
        }

        // Update properties of existingBetting with updatedBetting  
        existingBetting.EventName = updatedBetting.EventName;
        existingBetting.EventTime = updatedBetting.EventTime;
        existingBetting.EventImageUrl = updatedBetting.EventImageUrl;

        await _context.SaveChangesAsync();
        return existingBetting;
    }

    public async Task<bool> DeleteBettingEventAsync(Guid id)
    {
        var betting = await _context.Bettings.FindAsync(id);
        if (betting == null)
        {
            // Handle not found scenario
            return false;
        }

        _context.Bettings.Remove(betting);
        await _context.SaveChangesAsync();
        return true;
    }
    #endregion

    #region Bettor
    public async Task<Bettor> AddBettorAsync(Bettor bettor)
    {
        _context.Bettors.Add(bettor);
        await _context.SaveChangesAsync();
        return bettor;
    }

    public async Task UpdateUserBalanceAsync(User user, double amount)  
    {
        user.Balance -= (float)amount;

        await _context.SaveChangesAsync();
  
    }


    #endregion


}