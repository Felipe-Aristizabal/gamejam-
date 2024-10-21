using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityZoneManager : MonoBehaviour
{
    
    [SerializeField] UIController uiController;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerPositionState _playerPosition;

    private void FixedUpdate()
    {
        ActiveWarning();
    }

    public void ActiveWarning()
    {
        uiController.EnableWarning(_playerPosition.isWarning);
        
        if (_playerPosition.isRestart)
        {
            StartCoroutine(gameManager.RestartScene());
        }
    }

}
