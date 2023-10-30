using GamblerX.Application.Common.Interfaces.Persistence;
using GamblerX.Domain.Entities;

namespace GamblerX.Application.Services.Persistence;

public class BettingService : IBettingService
{
    private readonly IBettingRepository _bettingRepository;

    public BettingService(IBettingRepository bettingRepository)
    {
        _bettingRepository = bettingRepository;
    }

    public async Task<Betting> AddBettingAsync(Betting betting)
    {
        return await _bettingRepository.AddBettingAsync(betting);
    }

    public async Task<Betting> UpdateBettingAsync(Guid id, Betting updatedBetting)
    {    
        return await _bettingRepository.UpdateBettingAsync(id, updatedBetting) ?? throw new Exception("Could not update, Bet was not found !");
    }

    public async Task<bool> DeleteBettingAsync(Guid id)
    {
        return await _bettingRepository.DeleteBettingAsync(id);
    }
}
