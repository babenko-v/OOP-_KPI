namespace Lab3_OOP.Entity.GameEntities;

public class RandomRatingGameEntity : GameEntity
{
    public RandomRatingGameEntity(int playerId)
    {
        Random random = new Random();
        ChangeOfRating = random.Next(4, 15);
        PlayerId = playerId;
    }
}