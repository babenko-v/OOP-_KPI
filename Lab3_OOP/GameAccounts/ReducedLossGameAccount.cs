namespace Lab3_OOP.GameAccounts
{
    public class ReducedLossGameAccount : GameAccount
    {
        public ReducedLossGameAccount(string name, int rating) : base(name, rating) { }

        public override int CalculateLosePoints(int changeOfRating)
        {
            return changeOfRating / 2;
        }
    }
}