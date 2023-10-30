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

    public async Task<Betting> AddBettingAsync(Betting betting)
    {
        _context.Bettings.Add(betting);
        await _context.SaveChangesAsync();
        return betting;
    }

    public async Task<Betting?> UpdateBettingAsync(Guid id, Betting updatedBetting)  
    {
        var existingBetting = await _context.Bettings.FindAsync(id);
        if (existingBetting == null)
        {
            return null;
        }

        // Update properties of existingBetting with updatedBetting  
        existingBetting.EventName = updatedBetting.EventName;
        existingBetting.EventTime = updatedBetting.EventTime;
        existingBetting.BetCountTeam1 = updatedBetting.BetCountTeam1;
        existingBetting.BetCountTeam2 = updatedBetting.BetCountTeam2;
        existingBetting.TotalBetValueTeam1 = updatedBetting.TotalBetValueTeam1;
        existingBetting.TotalBetValueTeam2 = updatedBetting.TotalBetValueTeam2;
        
        await _context.SaveChangesAsync();
        return existingBetting;
    }

    public async Task<bool> DeleteBettingAsync(Guid id)
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

}