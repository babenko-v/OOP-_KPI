﻿namespace Lab3_OOP.Entity.GameEntities;

public class TrainingGameEntity : GameEntity
{
    public TrainingGameEntity(int playerId)
    {
        ChangeOfRating = 0;
        PlayerId = playerId;
    }
}