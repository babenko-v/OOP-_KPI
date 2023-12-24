using Lab3_OOP.Entity.GameEntities;
using Lab3_OOP.Entity;
using Lab3_OOP.GameAccounts;
using Lab3_OOP.Repository.IRepository;

namespace Lab3_OOP.Service
{
    public class GameService : IGameService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGameRepository _gameRepository;

        public GameService(IPlayerRepository playerRepository, IGameRepository gameRepository)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
        }

        public void CreateGame(GameEntity game)
        {
            _gameRepository.CreateGame(game);
        }

        public IEnumerable<GameEntity> ReadPlayerGamesByPlayerId(int playerId)
        {
            return _gameRepository.ReadAllGames().Where(g => g.PlayerId == playerId);
        }

        public IEnumerable<GameEntity> ReadGames()
        {
            return _gameRepository.ReadAllGames();
        }

        public void CreateAccount(PlayerEntity player)
        {
            _playerRepository.CreatePlayer(player);
        }

        public IEnumerable<PlayerEntity> ReadAccounts()
        {
            return _playerRepository.ReadAccounts();
        }

        public bool IsPlayerWinner(int playerId, int gameId)
        {
            GameEntity game = _gameRepository.ReadGameById(gameId);
            PlayerEntity player = _playerRepository.ReadAccountById(playerId);
            Random random = new Random();
            bool isWinner = random.Next(2) == 0;

            int changeOfRating = game.ChangeOfRating;

            if (isWinner)
            {
                player.CurrentRating += player.GameAccount.CalculateWinPoints(changeOfRating);
            }
            else
            {
                player.CurrentRating -= player.GameAccount.CalculateLosePoints(changeOfRating);

                if (player.CurrentRating < 1)
                {
                    player.CurrentRating = 1;
                }
            }

            _playerRepository.UpdateRating(player.Id, player.CurrentRating);

            return isWinner;
        }

        public int GetPlayerRating(int playerId)
        {
            PlayerEntity player = _playerRepository.ReadAccountById(playerId);
            return player.CurrentRating;
        }

        public string GetGameTypeName(GameEntity game)
        {
            return game switch
            {
                StandardGameEntity => "Standard Game",
                TrainingGameEntity => "Training Game",
                RandomRatingGameEntity => "Random Rating Game",
                _ => "Unknown Game Type"
            };
        }
    }
}
