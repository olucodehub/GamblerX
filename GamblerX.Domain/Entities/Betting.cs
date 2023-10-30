namespace GamblerX.Domain.Entities;

// A betting object
public class Betting
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public required string EventName { get; set; }
    public double MinimumBetValue { get; set; } = 1;
    public int BetCountTeam1 { get; set; }
    public int BetCountTeam2 { get; set; }
    public double TotalBetValueTeam1 { get; set; }
    public double TotalBetValueTeam2 { get; set; }
    public DateTime EventTime { get; set; }
}


// logged in user staking money to bet on a team
public class Bettor
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public Guid UserId {get; set;} 
    public Guid BettingId { get; set; }
    public double AmountBet { get; set; }
    public int TeamSelected { get; set; }  // 1 or 2
}
