using GamblerX.Domain.Entities;

namespace GamblerX.Application.Common.Interfaces.Persistence;


public interface IBettingRepository
{
    Task<Betting> AddBettingAsync(Betting betting);
    Task<Betting?> UpdateBettingAsync(Guid id, Betting updatedBetting);
    Task<bool> DeleteBettingAsync(Guid id);
}
