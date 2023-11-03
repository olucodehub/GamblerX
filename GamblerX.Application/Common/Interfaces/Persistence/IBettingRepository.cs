using GamblerX.Domain.Entities;

namespace GamblerX.Application.Common.Interfaces.Persistence;


public interface IBettingRepository
{
    Task<Betting> AddBettingEventAsync(Betting betting);
    Task<Betting?> UpdateBettingEventAsync(Guid id, Betting updatedBetting);
    Task<bool> DeleteBettingEventAsync(Guid id);
    Task<Betting?> GetBettingEventAsync(Guid id);

    Task<Bettor> AddBettorAsync(Bettor bettor);
    Task UpdateUserBalanceAsync(User user, double amount);
}
