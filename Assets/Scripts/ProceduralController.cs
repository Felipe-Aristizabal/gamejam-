using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ProceduralController : MonoBehaviour
{
    [SerializeField] private GameObject[] pointsBuildings;
    [SerializeField] private SOBuildingData buildingDataSO;
    
    [SerializeField]private Transform spawnParent;
    
    // Start is called before the first frame update
    void Start()
    {
        buildingDataSO.ClearBuiltData();
        PositionateBuildings();
    }

    public void PositionateBuildings()
    {
        foreach (GameObject point in pointsBuildings)
        {
            GameObject buildingToPosisionate = buildingDataSO.GetBuildingPrefab(spawnParent);
            buildingToPosisionate.transform.position = point.transform.position;
        }

        GetRandomBuilding();
    }

    private void GetRandomBuilding()
    {
        GameObject customerBuilding = spawnParent.GetChild(Random.Range(0, spawnParent.childCount)).gameObject;
        customerBuilding.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log(customerBuilding);
    }
}
