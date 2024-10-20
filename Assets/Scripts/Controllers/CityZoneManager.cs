using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityZoneManager : MonoBehaviour
{
    
    [SerializeField] UIController uiController;
    private PlayerPositionState _playerPosition;
    
    
    private void Start()
    {
        _playerPosition = FindObjectOfType<PlayerPositionState>();    
    }

    private void FixedUpdate()
    {
        ActiveWarning();
    }

    public void ActiveWarning()
    {
        uiController.EnableWarning(_playerPosition.isWarning);
        
        if (_playerPosition.isRestart)
        {
            uiController.EnableWarning(false);
            _playerPosition.isWarning = false;
            Debug.Log("I'm out");
        }
    }

}
