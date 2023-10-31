namespace GamblerX.Contracts.Persistence;
public record BettingRequest(
    string EventName,
    DateTime EventTime,
    string EventImageUrl,
    double MinimumBetValue);



    
  