using UnityEngine;

[CreateAssetMenu(fileName = "FlowerData", menuName = "ScriptableObjects/FlowerData", order = 1)]
public class FlowerData : ScriptableObject
{
    public int selectedPrefabIndex;

    public GameObject[] flowerPrefabs;
}
