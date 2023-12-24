using Lab3_OOP.Entity;
using Lab3_OOP.Entity.GameEntities;

namespace Lab3_OOP.Service;

public interface IGameService
{
    void CreateAccount(PlayerEntity player);
    IEnumerable<PlayerEntity> ReadAccounts();
    void CreateGame(GameEntity game);
    IEnumerable<GameEntity> ReadPlayerGamesByPlayerId(int playerId);
    IEnumerable<GameEntity> ReadGames();
    bool IsPlayerWinner(int playerId, int gameId);
    int GetPlayerRating(int playerId);
    string GetGameTypeName(GameEntity game);
}