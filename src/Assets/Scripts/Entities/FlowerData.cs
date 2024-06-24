using UnityEngine;

[CreateAssetMenu(fileName = "New Flower", menuName = "ScriptableObjects/Flower", order = 1)]
public class FlowerData : ScriptableObject
{
    public int selectedPrefabIndex;

    public GameObject[] flowerPrefabs;
}
