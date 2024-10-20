using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class Gain : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; 
    public int pointsToAdd = 10;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddCoins(pointsToAdd);
            Destroy(this.gameObject);
        }
    }
}
