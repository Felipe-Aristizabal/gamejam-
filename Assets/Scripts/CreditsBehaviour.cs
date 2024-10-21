using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBehaviour : MonoBehaviour
{
    public void ExitCredits()
    {
        gameObject.SetActive(false);
    }
    
    public void OpenSpecificUrl(string urlToOpen)
    {
        Application.OpenURL(urlToOpen);
    }
}
