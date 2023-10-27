namespace GamblerX.Domain.Entities;

public class Bet
{
    public int TotalNumberOfBets { get; set; }
    public double TotalBetValueTeam1 { get; set; }
    public double TotalBetValueTeam2 { get; set; }
    public required List<Bettor> Bettors { get; set; }
}

public class Bettor
{
    public Guid UserId {get; set;} 
    
    public double AmountStaked { get; set; }

    public int TeamSelected { get; set; }  // 1 or 2
}
