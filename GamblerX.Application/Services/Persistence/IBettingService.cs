using GamblerX.Domain.Entities;

namespace GamblerX.Application.Services.Persistence;


public interface IBettingService
{
    Task<Betting> AddBettingEvent(Betting betting);

    Task<Betting> UpdateBettingEvent(Guid id, Betting updatedBetting);

    Task<bool> DeleteBettingEvent(Guid id);

    Task<Bettor> PlaceBet(Bettor bettor);
}