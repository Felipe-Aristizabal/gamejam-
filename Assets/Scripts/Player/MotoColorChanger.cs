using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoColorChanger : MonoBehaviour
{
    public Material[] materials; // Lista de materiales disponibles
    public GameObject[] objectsToChange; // Lista de objetos a los que se les cambiará el material
    private int currentMaterialIndex = 0; // Índice actual de material
    private bool isShopModeActive = false; // Modo tienda activo o no
    private bool isMyMaterialsModeActive = false; // Modo "Mis materiales" activo o no
    private Material[] originalMaterials; // Materiales originales de los objetos antes de entrar en el modo tienda

    public List<Material> purchasedMaterials = new List<Material>(); // Lista de materiales comprados
    private int currentPurchasedMaterialIndex = 0; // Índice actual de la lista de materiales comprados

    public int costToFixColor = 10; // Costo para fijar el color
    public UIController uiController; // Referencia al script UIController para acceder a las monedas

    void Start()
    {
        // Inicializar el array para almacenar los materiales originales
        originalMaterials = new Material[objectsToChange.Length];
    }

    void Update()
    {
        // Activar o desactivar el modo tienda con la tecla "T"
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleShopMode();
        }

        // Activar o desactivar el modo "Mis materiales" con la tecla "Y"
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ToggleMyMaterialsMode();
        }

        // Si el modo tienda está activo, permitir cambiar y fijar el color
        if (isShopModeActive)
        {
            // Cambiar de material al presionar la tecla "M"
            if (Input.GetKeyDown(KeyCode.M))
            {
                ChangeMaterial();
            }

            // Intentar fijar el color al presionar la tecla "F"
            if (Input.GetKeyDown(KeyCode.F))
            {
                TryFixColor();
            }
        }

        // Si el modo "Mis materiales" está activo, permitir navegar y seleccionar
        if (isMyMaterialsModeActive)
        {
            // Moverse en la lista de materiales comprados con la tecla "N"
            if (Input.GetKeyDown(KeyCode.N))
            {
                MoveToNextPurchasedMaterial();
            }

            // Salir del modo "Mis materiales" con la tecla "B"
            if (Input.GetKeyDown(KeyCode.B))
            {
                ToggleMyMaterialsMode();
            }
        }
    }

    void ChangeMaterial()
    {
        // Avanzar al siguiente material en la lista
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;

        // Asignar el nuevo material a todos los objetos seleccionados
        foreach (GameObject obj in objectsToChange)
        {
            if (obj.TryGetComponent<Renderer>(out Renderer renderer))
            {
                renderer.material = materials[currentMaterialIndex];
            }
        }
    }

    void TryFixColor()
    {
        // Verificar si el UIController está asignado correctamente antes de proceder
        if (uiController == null)
        {
            Debug.LogError("UIController no asignado. Asegúrate de asignarlo en el Inspector.");
            return;
        }

        // Verificar si el jugador tiene suficientes monedas
        if (uiController.coins >= costToFixColor)
        {
            // Restar las monedas
            uiController.AddCoins(-costToFixColor);

            // Agregar el material actual a la lista de materiales comprados
            purchasedMaterials.Add(materials[currentMaterialIndex]);

            // Desactivar el modo tienda
            isShopModeActive = false;
            Debug.Log("Color fijado y modo tienda desactivado.");
        }
        else
        {
            // Si no hay suficientes monedas, mostrar un mensaje de advertencia
            Debug.Log("No tienes suficientes monedas para fijar el color.");
        }
    }

    void ToggleShopMode()
    {
        if (!isShopModeActive)
        {
            // Al entrar en el modo tienda, capturar los materiales originales
            CaptureOriginalMaterials();
            isShopModeActive = true;
            Debug.Log("Modo tienda activado. Puedes cambiar y fijar el color.");
        }
        else
        {
            // Si se sale del modo tienda sin fijar el color y no tiene suficiente dinero, restaurar materiales
            if (uiController.coins < costToFixColor)
            {
                RestoreOriginalMaterials();
                Debug.Log("No se fijó ningún color, restaurando materiales originales.");
            }
            isShopModeActive = false;
            Debug.Log("Modo tienda desactivado. No puedes cambiar ni fijar el color.");
        }
    }

    void CaptureOriginalMaterials()
    {
        // Guardar los materiales originales de los objetos
        for (int i = 0; i < objectsToChange.Length; i++)
        {
            if (objectsToChange[i].TryGetComponent<Renderer>(out Renderer renderer))
            {
                originalMaterials[i] = renderer.material;
            }
        }
    }

    void RestoreOriginalMaterials()
    {
        // Restaurar los materiales originales
        for (int i = 0; i < objectsToChange.Length; i++)
        {
            if (objectsToChange[i].TryGetComponent<Renderer>(out Renderer renderer))
            {
                renderer.material = originalMaterials[i];
            }
        }
    }

    void ToggleMyMaterialsMode()
    {
        if (!isMyMaterialsModeActive)
        {
            if (purchasedMaterials.Count > 0)
            {
                // Entrar en el modo "Mis materiales"
                isMyMaterialsModeActive = true;
                currentPurchasedMaterialIndex = 0;
                ApplyPurchasedMaterial();
                Debug.Log("Modo 'Mis materiales' activado.");
            }
            else
            {
                Debug.Log("No tienes materiales comprados.");
            }
        }
        else
        {
            // Salir del modo "Mis materiales"
            isMyMaterialsModeActive = false;
            Debug.Log("Modo 'Mis materiales' desactivado.");
        }
    }

    void MoveToNextPurchasedMaterial()
    {
        if (purchasedMaterials.Count > 0)
        {
            // Moverse al siguiente material en la lista de materiales comprados
            currentPurchasedMaterialIndex = (currentPurchasedMaterialIndex + 1) % purchasedMaterials.Count;
            ApplyPurchasedMaterial();
        }
    }

    void ApplyPurchasedMaterial()
    {
        // Aplicar el material comprado actual a todos los objetos seleccionados
        Material selectedMaterial = purchasedMaterials[currentPurchasedMaterialIndex];
        foreach (GameObject obj in objectsToChange)
        {
            if (obj.TryGetComponent<Renderer>(out Renderer renderer))
            {
                renderer.material = selectedMaterial;
            }
        }
    }
}
