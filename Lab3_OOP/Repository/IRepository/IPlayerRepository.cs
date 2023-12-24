using Lab3_OOP.Entity;

namespace Lab3_OOP.Repository.IRepository;

public interface IPlayerRepository
{
    void CreatePlayer(PlayerEntity player);
    PlayerEntity ReadPlayerById(int playerId);
    IEnumerable<PlayerEntity> ReadAllPlayers();
    
    void CreateAccount(PlayerEntity player);
    IEnumerable<PlayerEntity> ReadAccounts();
    PlayerEntity ReadAccountById(int playerId);
    void UpdateRating(int playerId, int newRating);
}