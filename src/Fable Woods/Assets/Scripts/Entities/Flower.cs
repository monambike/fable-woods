using UnityEngine;

public class Flower : MonoBehaviour
{
    public FlowerData flowerData;

    private GameObject _currentFlowerInstance;

    [SerializeField]
    public string stringChoice;

    public int selectedPrefabIndex;

    public GameObject SelectedFlower {
        get {
            if (flowerData != null && selectedPrefabIndex >= 0 && selectedPrefabIndex < flowerData.flowerPrefabs.Length) {
                return flowerData.flowerPrefabs[selectedPrefabIndex];
            }
            return null;
        }
    }

    private void Start()
    {
        UpdateFlowerInstance();
    }

    private void OnValidate()
    {
        // Ensure the selectedPrefabIndex is within the valid range
        if (flowerData != null)
        {
            selectedPrefabIndex = Mathf.Clamp(selectedPrefabIndex, 0, flowerData.flowerPrefabs.Length - 1);
        }

        if (!Application.isPlaying) return;

        UpdateFlowerInstance();
    }

    private void UpdateFlowerInstance()
    {
        DestroyCurrentInstance();

        GameObject prefab = GetFlowerPrefab();
        if (prefab != null)
        {
            _currentFlowerInstance = Instantiate(prefab, transform);
        }
    }

    private void DestroyCurrentInstance()
    {
        if (_currentFlowerInstance != null)
        {
            Destroy(_currentFlowerInstance);
        }
    }

    private GameObject GetFlowerPrefab()
    {
        if (flowerData == null || flowerData.flowerPrefabs.Length == 0)
        {
            Debug.LogWarning("FlowerData is not assigned or contains no prefabs.");
            return null;
        }

        int index = selectedPrefabIndex;
        if (index >= 0 && index < flowerData.flowerPrefabs.Length)
        {
            return flowerData.flowerPrefabs[index];
        }
        else
        {
            Debug.LogWarning("FlowerType index out of range.");
            return null;
        }
    }
}
