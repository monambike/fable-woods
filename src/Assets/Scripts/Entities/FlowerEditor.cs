using UnityEditor;

[CustomEditor(typeof(Flower))]
public class SomeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Desenha o inspetor padrão para que possamos ver todas as propriedades padrão
        DrawDefaultInspector();

        Flower flower = (Flower)target;

        if (flower.flowerData != null && flower.flowerData.flowerPrefabs.Length > 0)
        {
            // Certifique-se de que _choices tem o mesmo tamanho que flowerPrefabs
            string[] _choices = new string[flower.flowerData.flowerPrefabs.Length];

            // Preenche a lista de escolhas com os nomes dos prefabs
            for (int i = 0; i < flower.flowerData.flowerPrefabs.Length; i++)
            {
                _choices[i] = flower.flowerData.flowerPrefabs[i] != null ? flower.flowerData.flowerPrefabs[i].name : "Missing Prefab";
            }

            // Desenha o popup para selecionar o prefab
            flower.selectedPrefabIndex = EditorGUILayout.Popup("Select Prefab", flower.selectedPrefabIndex, _choices);

            // Atualiza a stringChoice com o nome do prefab selecionado
            if (flower.selectedPrefabIndex >= 0 && flower.selectedPrefabIndex < _choices.Length)
            {
                flower.stringChoice = _choices[flower.selectedPrefabIndex];
            }

            // Marca o objeto como sujo para garantir que as alterações sejam salvas
            EditorUtility.SetDirty(target);
        }
        else
        {
            EditorGUILayout.HelpBox("FlowerData or FlowerPrefabs is not set or is empty.", MessageType.Warning);
        }
    }
}