using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProceduralController : MonoBehaviour
{
    [SerializeField] private GameObject[] pointsBuildings;
    [SerializeField] private SOBuildingData buildingDataSO;
    
    [SerializeField] private Transform spawnParent;
    [SerializeField] private GameObject noteCamera;

    [SerializeField] private Button[] buttonsChangePreview = new Button[3];
    private GameObject[] selectedBuildings = new GameObject[3];

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

        GetRandomBuildings();
        AssignButtonCallbacks();
    }

    private void GetRandomBuildings()
    {
        List<int> usedIndices = new List<int>(); 

        for (int i = 0; i < 3; i++) 
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, spawnParent.childCount);
            } while (usedIndices.Contains(randomIndex));

            usedIndices.Add(randomIndex); 
            GameObject customerBuilding = spawnParent.GetChild(randomIndex).gameObject;
            selectedBuildings[i] = customerBuilding;
            customerBuilding.transform.GetChild(0).gameObject.SetActive(true);

            if (i == 0) 
            {
                ChangeCameraTransform(customerBuilding);
            }

            Debug.Log(customerBuilding.name); 
        }
    }

    private void AssignButtonCallbacks()
    {
        for (int i = 0; i < buttonsChangePreview.Length; i++)
        {
            int index = i; 
            buttonsChangePreview[i].onClick.AddListener(() => {
                ChangeCameraTransform(selectedBuildings[index]); 
                AnimateButton(buttonsChangePreview[index]); 
            });
        }
    }

    private void AnimateButton(Button button)
    {
        // This animation will be created by @SebastianEscobar
    }

    private void ChangeCameraTransform(GameObject selectedBuilding)
    {
        noteCamera.transform.position = selectedBuilding.transform.GetChild(1).position;
        noteCamera.transform.rotation = selectedBuilding.transform.GetChild(1).rotation;
    }
}
