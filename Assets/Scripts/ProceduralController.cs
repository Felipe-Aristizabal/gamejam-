using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ProceduralController : MonoBehaviour
{
    [SerializeField] private GameObject[] pointsBuildings;
    [SerializeField] private SOBuildingData buildingDataSO;
    
    // Start is called before the first frame update
    void Start()
    {
        buildingDataSO.ClearBuiltData();
        PositionateBuildings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PositionateBuildings()
    {
        foreach (GameObject point in pointsBuildings)
        {
            GameObject buildingToPosisionate = buildingDataSO.GetBuildingPrefab();
            buildingToPosisionate.transform.position = point.transform.position;
        }
    }
}
