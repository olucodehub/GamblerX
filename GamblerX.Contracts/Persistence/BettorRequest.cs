namespace GamblerX.Contracts.Persistence;
public record BettorRequest(
    Guid BettingId,
    double AmountBet,
    int TeamSelected );


