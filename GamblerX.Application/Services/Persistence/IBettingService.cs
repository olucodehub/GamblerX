using GamblerX.Domain.Entities;

namespace GamblerX.Application.Services.Persistence;


public interface IBettingService
{
    Task<Betting> AddBettingAsync(Betting betting);

    Task<Betting> UpdateBettingAsync(Guid id, Betting updatedBetting);

    Task<bool> DeleteBettingAsync(Guid id);

}