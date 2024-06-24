using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "ScriptableObjects/Crop", order = 1)]
public class CropData : ItemData
{
    [Header("After Harvest Regrow")]

    /// <summary>
    /// Time it takes for the crop to regrow after harvest.
    /// </summary>
    public float timeToRegrow;

    /// <summary>
    /// Number of times the crop can regrow.
    /// </summary>
    public float regrowTimes;

    /// <summary>
    /// Current growth stage of the crop.
    /// </summary>
    public Stage currentStage;

    /// <summary>
    /// Property to check if the crop can be harvested.
    /// </summary>
    public bool CanHarvest => currentStage == Stage.Fruit;

    /// <summary>
    /// Enumeration for crop growth stages.
    /// </summary>
    public enum Stage
    {
        /// <summary>
        /// Crop in seed stage.
        /// </summary>
        Seed,

        /// <summary>
        /// Crop in fruit stage.
        /// </summary>
        Fruit,

        /// <summary>
        /// Cropt in empty stage.
        /// </summary>
        Empty
    }
}
