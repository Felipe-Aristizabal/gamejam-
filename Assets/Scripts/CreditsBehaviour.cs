using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBehaviour : MonoBehaviour
{
    public void ExitSpecificGameObject(GameObject gameObjectToExit)
    {
        gameObjectToExit.SetActive(false);
    }
    
    public void OpenSpecificUrl(string urlToOpen)
    {
        Application.OpenURL(urlToOpen);
    }
}
