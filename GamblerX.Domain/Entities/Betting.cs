namespace GamblerX.Domain.Entities;

// A betting Event object
public class Betting
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public required string EventName { get; set; }
    public DateTime EventTime { get; set; }
    public string? EventImageUrl { get; set; }
    public double MinimumBetValue { get; set; } = 1;
    public int BetCountTeam1 { get; set; }
    public int BetCountTeam2 { get; set; }
    public double TotalBetValueTeam1 { get; set; }
    public double TotalBetValueTeam2 { get; set; }
    public int WinningTeam { get; set; }
}


