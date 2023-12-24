using Lab3_OOP.Entity;
using Lab3_OOP.Entity.GameEntities;

namespace Lab3_OOP;

public class DbContext
{
    public List<PlayerEntity> Players { get; } = new();
    public List<GameEntity> Games { get; } = new();
}