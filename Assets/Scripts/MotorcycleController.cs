using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleController : MonoBehaviour
{
    public float acceleration = 0.1f; // Aceleración de la moto
    public float maxSpeed = 20f; // Velocidad máxima hacia adelante
    public float maxReverseSpeed = 7f; // Velocidad máxima hacia atrás (más lenta)
    public float turnSpeed = 50f; // Velocidad de rotación

    private float currentSpeed = 0f; // Velocidad actual de la moto
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente RigidBody
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical"); // Entrada del jugador para adelante/atrás
        float turnInput = Input.GetAxis("Horizontal"); // Entrada para la rotación
        float turn = 0f; // Inicialmente, no hay rotación

        // Aceleración hacia adelante
        if (moveInput > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed); // Limitar la velocidad máxima hacia adelante
        }
        // Aceleración hacia atrás (más lenta)
        else if (moveInput < 0)
        {
            currentSpeed -= acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -maxReverseSpeed, 0f); // Limitar la velocidad máxima hacia atrás
        }
        // Desaceleración cuando no hay input
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, acceleration * Time.deltaTime);
        }

        // Solo permitir la rotación si la moto está en movimiento (aceleración hacia adelante o atrás)
        if (Mathf.Abs(currentSpeed) > 0.1f) // Si la velocidad es mayor que un valor mínimo
        {
            turn = turnInput * turnSpeed * Time.deltaTime;
        }

        // Aplicar el movimiento
        Vector3 moveDirection = transform.forward * currentSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        // Aplicar la rotación solo si hay velocidad
        transform.Rotate(0, turn, 0);
    }
}

