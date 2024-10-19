using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "buildingData")]
public class SOBuildingData : ScriptableObject
{
    [SerializeField] private List<GameObject> buildingPrefab;
    [SerializeField] private List<Texture> buildingTexture;
    [SerializeField] private GameObject buildingPrefabDefault;
    private Dictionary<int, List<int>> _builtGeneratedData = new Dictionary<int, List<int>>();

    private int positionBuildingPrefab = -1;
    private int positionBuildingTexture = -1;
    private int counterToRegenerateBuildingPrefab = 0;
    
    public GameObject GetBuildingPrefab()
    {
        positionBuildingPrefab = Random.Range(0, buildingPrefab.Count);
        positionBuildingTexture = Random.Range(0, buildingTexture.Count);

        if (!ValidateBuildingData())
        {
            if (!_builtGeneratedData.ContainsKey(positionBuildingPrefab))
            {
                _builtGeneratedData[positionBuildingPrefab] = new List<int>();
            }
            _builtGeneratedData[positionBuildingPrefab].Add(positionBuildingTexture);

            GameObject building = Instantiate(buildingPrefab[positionBuildingPrefab]);
            Texture texture = buildingTexture[positionBuildingTexture];
        
            Renderer _renderer = building.GetComponent<Renderer>();
            if (_renderer == null)
            {
                Debug.LogError("Renderer not found on building prefab!");
                return buildingPrefabDefault;
            }
        
            Material[] mat = _renderer.materials;
            if (mat == null || mat.Length == 0)
            {
                Debug.LogError("No materials found on building prefab!");
                return buildingPrefabDefault;
            }

            foreach (Material material in mat)
            {
                if (material.mainTexture != null && material.mainTexture.name == "ColorDefaultPalette")
                {
                    material.SetTexture("_BaseMap", texture);
                }
            }

            return building;
        }
        else
        {
            if (counterToRegenerateBuildingPrefab < 2)
            {
                counterToRegenerateBuildingPrefab++;
                return GetBuildingPrefab();
            }
            else
            {
                counterToRegenerateBuildingPrefab = 0;
                return Instantiate(buildingPrefabDefault);
            }
        }
    }

    public void ClearBuiltData()
    {
        _builtGeneratedData.Clear();
    }

    public bool ValidateBuildingData()
    {
        if (_builtGeneratedData.ContainsKey(positionBuildingPrefab))
        {
            return _builtGeneratedData[positionBuildingPrefab].Contains(positionBuildingTexture);
        }
        return false;
    }
}
