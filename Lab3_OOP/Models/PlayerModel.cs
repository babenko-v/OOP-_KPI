using Lab3_OOP.GameAccounts;

namespace Lab3_OOP.Entity;

public class PlayerEntity
{
    public int Id { get; set; }
    public string UserName { get; }
    public int CurrentRating { get; set; }
    public GameAccount GameAccount { get; }
    
    public PlayerEntity(GameAccount gameAccount)
    {
        UserName = gameAccount.UserName;
        CurrentRating = gameAccount.CurrentRating;
        GameAccount = gameAccount;
    }
}