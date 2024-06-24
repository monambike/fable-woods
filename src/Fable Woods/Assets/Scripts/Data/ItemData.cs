using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item", order = 0)]
public class ItemData : ScriptableObject
{
    [Header("Basic Information")]

    /// <summary>
    /// Icon representing the item.
    /// </summary>
    public Sprite icon;

    /// <summary>
    /// Unique ID for the item.
    /// </summary>
    public int itemID;

    /// <summary>
    /// Name of the item.
    /// </summary>
    public string itemName;

    [Header("Price")]
    /// <summary>
    /// Price to sell the item.
    /// </summary>
    public int sellPrice;

    /// <summary>
    /// Price to buy the item.
    /// </summary>
    public int buyPrice;
}
