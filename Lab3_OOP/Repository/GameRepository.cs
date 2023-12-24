using Lab3_OOP.Entity.GameEntities;
using Lab3_OOP.Repository.IRepository;

namespace Lab3_OOP.Repository;

public class GameRepository: IGameRepository
{
    private readonly List<GameEntity> ggames;

    public GameRepository(List<GameEntity> games)
    {
        ggames = games;
    }

    public void CreateGame(GameEntity game)
    {
        game.Id = ggames.Count + 1;
        ggames.Add(game);
    }

    public GameEntity ReadGameById(int gameId)
    {
        return ggames.FirstOrDefault(g => g.Id == gameId) ?? throw new InvalidOperationException();
    }

    public IEnumerable<GameEntity> ReadAllGames()
    {
        return ggames;
    }
}