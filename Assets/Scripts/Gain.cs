using System;
using System.Collections;
using System.Collections.Generic;
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

    // Función que detecta cuando algo entra en el Trigger del Gain
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Llamar a la función AddCoins del CoinManager para sumar puntos
            uIController.AddCoins(pointsToAdd);
        }
    }
}
