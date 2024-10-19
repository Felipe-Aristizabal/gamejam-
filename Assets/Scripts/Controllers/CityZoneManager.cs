using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityZoneManager : MonoBehaviour
{
    
    private PlayerPositionState _playerPosition;
    
    private void Start()
    {
        _playerPosition = FindObjectOfType<PlayerPositionState>();    
    }

    public void ActiveWarning()
    {
        if (_playerPosition.isWarning)
        {
            // TODO: HERE IS NECESSARY APLLY THE LOGIC FOR ACTIVE THE WARNING
        }
        else
        {
            // TODO: HERE IS NECESSARY APLLY THE LOGIC FOR DESACTIVE THE WARNING
        }
        
    }

    public void Restart()
    {
        if (_playerPosition.isRestart)
        {
            // TODO: HERE IS NECESSARY APLLY THE LOGIC FOR ACTIVE THE WARNING
        }
        else
        {
            // TODO: HERE IS NECESSARY APLLY THE LOGIC FOR DESACTIVE THE WARNING
        }
    }
}
