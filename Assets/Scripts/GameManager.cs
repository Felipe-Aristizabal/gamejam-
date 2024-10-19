using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Referencia al TextMeshPro en el Canvas
    private int coins = 0; // Valor inicial de las monedas

    void Start()
    {
        // Inicializar el valor de las monedas en 0 y actualizar el texto
        UpdateCoinText();
    }

    // Función para sumar puntos
    public void AddCoins(int amount)
    {
        coins += amount; // Sumar el valor pasado como parámetro
        UpdateCoinText(); // Actualizar el texto
    }

    // Función para actualizar el texto del TextMeshPro
    void UpdateCoinText()
    {
        coinText.text = coins.ToString(); // Convertir el valor a texto y mostrarlo
    }
}
