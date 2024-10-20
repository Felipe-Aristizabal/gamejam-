using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionState : MonoBehaviour
{
    public bool isWarning;
    public bool isRestart;
    private void OnTriggerEnter(Collider other)
    {
        // if (other.tag == "WarningZone")
        // {
        //     isWarning = true;
        // }

        if (other.tag == "Restart")
        {
            isRestart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WarningZone")
        {
            isWarning = false;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "WarningZone")
        {
            isWarning = true;
        }
    }
}
