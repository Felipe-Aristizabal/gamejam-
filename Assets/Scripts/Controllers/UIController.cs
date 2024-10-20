using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Referencia al TextMeshPro en el Canvas
    public int coins = 0; // Valor inicial de las monedas
    
    public GameObject warningZonePanel;

    [SerializeField] private PlayerPositionState _playerPosition;
    

    void Start()
    {
        UpdateCoinText();

        if (!_playerPosition)
        {
            _playerPosition = FindObjectOfType<PlayerPositionState>();
        }
    }
    
    private void FixedUpdate()
    {
        ActiveWarning();
    }

    public void ActiveWarning()
    {
        EnableWarning(_playerPosition.isWarning);
        
        if (_playerPosition.isRestart)
        {
            EnableWarning(false);
            _playerPosition.isWarning = false;
            Debug.Log("I'm out");
        }
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

    public void EnableWarning(bool value)
    {
        warningZonePanel.SetActive(value);
    }
}
