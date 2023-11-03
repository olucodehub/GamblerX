namespace GamblerX.Domain.Entities;


// logged in user betting on a team
public class Bettor
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public Guid UserId {get; set;} 
    public Guid BettingId { get; set; }
    public double AmountBet { get; set; }
    public int TeamSelected { get; set; }  // 1 or 2
}
