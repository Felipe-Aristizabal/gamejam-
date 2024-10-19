using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gain : MonoBehaviour
{
    [SerializeField] private GameManager uiController; // Referencia al script CoinManager
    public int pointsToAdd = 10; // Valor de puntos a sumar cuando el jugador entre

    // Función que detecta cuando algo entra en el Trigger del Gain
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Llamar a la función AddCoins del CoinManager para sumar puntos
            uiController.AddCoins(pointsToAdd);
        }
    }
}
