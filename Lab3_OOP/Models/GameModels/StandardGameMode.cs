namespace Lab3_OOP.Entity.GameEntities;

public class StandardGameEntity: GameEntity
{
    public StandardGameEntity(int changeOfRating, int playerId)
    {
        ChangeOfRating = changeOfRating;
        PlayerId = playerId;
    }
}