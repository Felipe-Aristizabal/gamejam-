using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
