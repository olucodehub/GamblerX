namespace GamblerX.Domain.Entities;


public class User
{
    public Guid Id {get; set;} = Guid.NewGuid();

    public string UserName {get; set;}  = string.Empty;

    public string Email {get; set;}  = string.Empty;

    public string Password {get; set;}  = string.Empty;

    public float Balance {get; set;} 

    //public string Wallet {get; set;}  = string.Empty;
}