namespace GamblerX.Contracts.Persistence;

public record BettingResponse(
    Guid Id,
    string EventName,
    DateTime EventTime);