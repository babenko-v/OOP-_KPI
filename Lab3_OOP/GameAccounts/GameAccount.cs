namespace Lab3_OOP.GameAccounts;

public abstract class GameAccount
{
    public string UserName { get; }
    public int CurrentRating { get; }

    public GameAccount(string name, int rating)
    {
        if (rating < 1)
            rating = 1;

        UserName = name;
        CurrentRating = rating;
    }

    public virtual int CalculateWinPoints(int changeOfRating)
    {
        return changeOfRating;
    }
    public virtual int CalculateLosePoints(int changeOfRating)
    {
        return  changeOfRating;
    }
}