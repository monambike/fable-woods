using UnityEngine;

public class Crop : Item
{
    [Header("After Harvest Regrow")]

    public float timeToRegrow;

    public float regrowTimes;

    public Stage currentStage;

    public bool CanHarvest => currentStage == Stage.Fruit; 

    public enum Stage
    {
        Seed,
        Fruit,
        Empty
    }
}