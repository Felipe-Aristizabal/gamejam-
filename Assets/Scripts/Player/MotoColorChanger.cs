using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotoColorChanger : MonoBehaviour
{
    public Material[] materials; // Lista de materiales disponibles
    public GameObject[] objectsToChange; // Lista de objetos a los que se les cambiará el material
    public GameObject colorSelectionCanvas; // El Canvas para seleccionar el color
    public Text colorNameText; // Texto que mostrará el nombre del color
    public Button leftArrowButton; // Botón para moverse a la izquierda
    public Button rightArrowButton; // Botón para moverse a la derecha
    public Button selectButton; // Botón para seleccionar el color

    private int currentMaterialIndex = 0; // Índice del material actual

    void Start()
    {
        // Inicialmente el Canvas está desactivado
        colorSelectionCanvas.gameObject.SetActive(false);

        // Asignar las funciones a los botones
        leftArrowButton.onClick.AddListener(SelectPreviousColor);
        rightArrowButton.onClick.AddListener(SelectNextColor);
        selectButton.onClick.AddListener(FixColor);
    }

    void Update()
    {
        // Activar o desactivar el Canvas al presionar "P"
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleColorSelectionCanvas();
            Time.timeScale = 0;
        }
    }

    // Función para mostrar/ocultar el Canvas de selección de color
    void ToggleColorSelectionCanvas()
    {
        bool isActive = colorSelectionCanvas.gameObject.activeSelf;
        colorSelectionCanvas.gameObject.SetActive(!isActive);

        // Actualizar el nombre del color si el canvas está activo
        if (!isActive)
        {
            UpdateColorName();
        }
    }

    // Función para seleccionar el color anterior en la lista
    void SelectPreviousColor()
    {
        currentMaterialIndex--;
        if (currentMaterialIndex < 0)
        {
            currentMaterialIndex = materials.Length - 1;
        }
        UpdateColorName();
        ApplyCurrentColor();
    }

    // Función para seleccionar el siguiente color en la lista
    void SelectNextColor()
    {
        currentMaterialIndex++;
        if (currentMaterialIndex >= materials.Length)
        {
            currentMaterialIndex = 0;
        }
        UpdateColorName();
        ApplyCurrentColor();
    }

    // Función para fijar el color seleccionado y desactivar el Canvas
    void FixColor()
    {
        ApplyCurrentColor();
        colorSelectionCanvas.gameObject.SetActive(false); // Desactivar el Canvas
        Time.timeScale = 1;
    }

    // Función para aplicar el color actual a los objetos seleccionados
    void ApplyCurrentColor()
    {
        Material selectedMaterial = materials[currentMaterialIndex];
        foreach (GameObject obj in objectsToChange)
        {
            if (obj.TryGetComponent<Renderer>(out Renderer renderer))
            {
                renderer.material = selectedMaterial;
            }
        }
    }

    // Función para actualizar el nombre del color en el texto del Canvas
    void UpdateColorName()
    {
        string materialName = materials[currentMaterialIndex].name;
        colorNameText.text = materialName; // Cambiar el texto del color seleccionado
    }
}
