using Lab3_OOP.Entity;
using Lab3_OOP.Repository.IRepository;

namespace Lab3_OOP.Repository;

public class PlayerRepository: IPlayerRepository
{
    private readonly List<PlayerEntity> pplayers;

    public PlayerRepository(List<PlayerEntity> players)
    {
        pplayers = players;
    }

    public void CreatePlayer(PlayerEntity player)
    {
        player.Id = pplayers.Count + 1;
        pplayers.Add(player);
    }

    public PlayerEntity ReadPlayerById(int playerId)
    {
        return pplayers.FirstOrDefault(p => p.Id == playerId) ?? throw new InvalidOperationException();
    }

    public IEnumerable<PlayerEntity> ReadAllPlayers()
    {
        return pplayers;
    }
    
    public void CreateAccount(PlayerEntity player)
    {
        player.Id = pplayers.Count + 1;
        pplayers.Add(player);
    }

    public IEnumerable<PlayerEntity> ReadAccounts()
    {
        return pplayers;
    }
    
    public PlayerEntity ReadAccountById(int playerId)
    {
        return pplayers.FirstOrDefault(p => p.Id == playerId) ?? throw new InvalidOperationException();
    }
    
    public void UpdateRating(int playerId, int newRating)
    {
        var player = pplayers.FirstOrDefault(p => p.Id == playerId);
        if (player != null)
        {
            player.CurrentRating = newRating;
        }
    }
}