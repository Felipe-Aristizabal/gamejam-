using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class Gain : MonoBehaviour
{
    [SerializeField] private UIController uIController; // Referencia al script CoinManager
    public int pointsToAdd = 10; // Valor de puntos a sumar cuando el jugador entre

    private void Start()
    {
        uIController = FindObjectOfType<UIController>();
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
