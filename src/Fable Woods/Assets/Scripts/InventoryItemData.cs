using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item Data", menuName = "ScriptableObjects/Inventory Item Data", order = 1)]
public class InventoryItemData : ScriptableObject
{
    public string id;

    public string name;

    public string description;

    public Sprite icon;

    public GameObject prefab;
}