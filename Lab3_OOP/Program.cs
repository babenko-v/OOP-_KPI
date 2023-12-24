using System.Text;
using Lab3_OOP.Entity;
using Lab3_OOP.Entity.GameEntities;
using Lab3_OOP.GameAccounts;
using Lab3_OOP.Repository;
using Lab3_OOP.Service;

namespace Lab3_OOP
{
    public abstract class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DbContext dbContext = new DbContext();
            PlayerRepository playerRepository = new PlayerRepository(dbContext.Players);
            GameRepository gameRepository = new GameRepository(dbContext.Games);
            IGameService gameService = new GameService(playerRepository, gameRepository);
            
            PlayerEntity player1 = new PlayerEntity(new StandardGameAccount("Alex", 325));
            PlayerEntity player2 = new PlayerEntity(new ReducedLossGameAccount("Mark", 283));
            PlayerEntity player3 = new PlayerEntity(new WinningStreakGameAccount("Savina", 71));

            gameService.CreateAccount(player1);
            gameService.CreateAccount(player2);
            gameService.CreateAccount(player3);

            GameEntity standardGame1 = new StandardGameEntity(20, player1.Id);
            gameService.CreateGame(standardGame1);
            GameEntity randomGame1 = new RandomRatingGameEntity(player1.Id);
            gameService.CreateGame(randomGame1);
            GameEntity trainingGame1 = new TrainingGameEntity(player1.Id);
            gameService.CreateGame(trainingGame1);
            
            
            GameEntity standardGame2 = new StandardGameEntity(10, player2.Id);
            gameService.CreateGame(standardGame2);
            GameEntity  randomGame2 = new RandomRatingGameEntity(player2.Id);
            gameService.CreateGame(randomGame2);
            GameEntity trainingGame2 = new TrainingGameEntity(player2.Id);
            gameService.CreateGame(trainingGame2);
            
            GameEntity standardGame3 = new StandardGameEntity(30, player3.Id);
            gameService.CreateGame(standardGame3);
            GameEntity randomGame3 = new RandomRatingGameEntity(player3.Id);
            gameService.CreateGame(randomGame3);
            GameEntity trainingGame3 = new TrainingGameEntity(player3.Id);
            gameService.CreateGame(trainingGame3);
            
            

            Console.WriteLine("List of all players:");
            foreach (var player in gameService.ReadAccounts())
            {
                Console.WriteLine($"{player.Id}. {player.UserName} - Rating: {player.CurrentRating}");
            }

            PrintPlayerGamesInfo(gameService, player1);
            PrintPlayerGamesInfo(gameService, player2);
            PrintPlayerGamesInfo(gameService, player3);

            Console.WriteLine("\nList of all game:");
            foreach (var game in gameService.ReadGames())
            {
                PrintGameInfo(gameService, game);
            }
        }
        
        private static void PrintPlayerGamesInfo(IGameService gameService, PlayerEntity player)
        {
            Console.WriteLine($"\nList of all game {player.UserName}:");
            foreach (var game in gameService.ReadPlayerGamesByPlayerId(player.Id))
            {
                PrintGameInfo(gameService, game);
            }
        }
        
        private static void PrintGameInfo(IGameService gameService, GameEntity game)
        {
            var result = gameService.IsPlayerWinner(game.PlayerId, game.Id) ? "Win" : "Lose";
            Console.WriteLine($"Game #{game.Id} - Result: {result}, Rating Change: {game.ChangeOfRating}, " +
                              $"New Rating: {gameService.GetPlayerRating(game.PlayerId)}, Game Type: " +
                              $"{gameService.GetGameTypeName(game)}");
        }
    }
}