using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController uIController;
    
    
    
    
    // Method for update the coins TXT
    public void AddCoins(int amount)
    {
        uIController.coins += amount; // Sumar el valor pasado como parámetro
        uIController.UpdateCoinText(); // Actualizar el texto
    }
}
