using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController uIController;
    
    [Header("Menu Items")]
    [SerializeField] private GameObject catPizzaEnv;
    [SerializeField] private GameObject catMenu;
    [SerializeField] private GameObject catMoto;
    [SerializeField] private GameObject catPizzaBox;
    
    [Header("Game Items")]
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject minimapCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCanva;
    
    
    // Method for update the coins TXT
    public void AddCoins(int amount)
    {
        uIController.coins += amount; // Sumar el valor pasado como parámetro
        uIController.UpdateCoinText(); // Actualizar el texto
    }

    public void SwitchCatPizza(bool value)
    {
        StartCoroutine((PlayAnims()));
    }

    IEnumerator PlayAnims()
    {
        catMenu.GetComponent<Animator>().SetBool("isPlaying", true);

        yield return new WaitForSeconds(1f);
        catMenu.SetActive(false);
        catPizzaBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        catMoto.GetComponent<Animator>().SetBool("isPlaying", true);
        
        yield return new WaitForSeconds(2f);
        mainCamera.SetActive(true);
        player.SetActive(true);
        mainCanva.SetActive(true);
        minimapCamera.SetActive(true);
        
        catPizzaEnv.SetActive(false);
    }
    
    
}
