namespace GamblerX.Contracts.Persistence;
public record BettingRequest(
    string EventName,
    DateTime EventTime,
    double MinimumBetValue);



    
  