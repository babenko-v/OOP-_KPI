using Lab3_OOP.Entity.GameEntities;

namespace Lab3_OOP.Repository.IRepository;

public interface IGameRepository
{
    void CreateGame(GameEntity game);
    GameEntity ReadGameById(int gameId);
    IEnumerable<GameEntity> ReadAllGames();
}