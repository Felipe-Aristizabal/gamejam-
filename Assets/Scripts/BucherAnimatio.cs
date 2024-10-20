using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonMover : MonoBehaviour
{
    public float moveDistance = 50f; // Distancia a mover el botón
    public float duration = 0.3f; // Duración de la animación
    private Vector3 originalPosition;
    private bool isMovedDown = false;

    void Start()
    {
        originalPosition = transform.localPosition; // Guarda la posición original

        // Añade el listener al botón
        GetComponent<Button>().onClick.AddListener(ToggleButtonPosition);
    }

    void ToggleButtonPosition()
    {
        if (isMovedDown)
        {
            // Regresar a la posición original
            StartCoroutine(MoveToPosition(originalPosition));
        }
        else
        {
            // Mover hacia abajo
            Vector3 targetPosition = originalPosition - new Vector3(0, moveDistance, 0);
            StartCoroutine(MoveToPosition(targetPosition));
        }

        // Cambia el estado
        isMovedDown = !isMovedDown;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera el siguiente frame
        }

        transform.localPosition = targetPosition; // Asegura que la posición final sea exacta
    }
}
