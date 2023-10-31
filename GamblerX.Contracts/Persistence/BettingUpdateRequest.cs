namespace GamblerX.Contracts.Persistence;
public record BettingUpdateRequest(
    string? EventName,
    DateTime? EventTime,
    string? EventImageUrl,
    int BetCountTeam1,
    int BetCountTeam2,
    double TotalBetValueTeam1,
    double TotalBetValueTeam2);



    
  