namespace Lab3_OOP.GameAccounts
{
    public class WinningStreakGameAccount : GameAccount
    {
        private int _consWins;

        public WinningStreakGameAccount(string name, int rating) : base(name, rating)
        {
            _consWins = 4;
        
        }

        public override int CalculateWinPoints(int changeOfRating)
        {
            _consWins++;
            if (_consWins >= 3)
            {
                
                return changeOfRating+100;
            }

            return changeOfRating;
        }

        public override int CalculateLosePoints(int changeOfRating)
        {
            _consWins = 0;
  
            return changeOfRating;
        }
    }
}