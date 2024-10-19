using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Referencia al TextMeshPro en el Canvas
    public int coins = 0; // Valor inicial de las monedas

    void Start()
    {
        UpdateCoinText();
    }

    // Función para sumar puntos
    public void AddCoins(int amount)
    {
        coins += amount; // Sumar el valor pasado como parámetro
        UpdateCoinText(); // Actualizar el texto
    }

    // Función para actualizar el texto del TextMeshPro
    public void UpdateCoinText()
    {
        coinText.text = coins.ToString(); // Convertir el valor a texto y mostrarlo
    }
}
