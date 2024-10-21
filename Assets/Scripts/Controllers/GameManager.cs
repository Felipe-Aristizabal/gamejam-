using System;
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

    [SerializeField] private Rigidbody rb;

    // Variables para guardar la posición inicial del jugador
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    

    private void Start()
    {
        // Guardar la posición y rotación inicial del jugador
        _initialPosition = player.transform.position;
        _initialRotation = player.transform.rotation;

        // rb = player.GetComponent<Rigidbody>(); // Si quieres habilitar esto más tarde
    }

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
        
        Debug.Log(_initialPosition);
        mainCanva.SetActive(true);
        minimapCamera.SetActive(true);
        
        catPizzaEnv.SetActive(false);
    }

    public IEnumerator RestartScene()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;

        // Mover el jugador a la posición inicial guardada
        player.transform.position = _initialPosition;
        player.transform.rotation = _initialRotation;

        yield return new WaitForSeconds(0.1f);
        rb.constraints = RigidbodyConstraints.None;
        
        player.GetComponent<PlayerPositionState>().isRestart = false;
        mainCamera.SetActive(false);
        player.SetActive(false);
        mainCanva.SetActive(false);
        minimapCamera.SetActive(false);
        
        catPizzaEnv.SetActive(true);
        catMenu.SetActive(true);
        catPizzaBox.SetActive(false);
        
        catPizzaBox.GetComponent<Animator>().Rebind();
        catMenu.GetComponent<Animator>().Rebind();
        catMoto.GetComponent<Animator>().Rebind();
    }
}
