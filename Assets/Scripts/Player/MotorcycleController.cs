using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleController : MonoBehaviour
{
    public float acceleration = 0.1f; // Aceleración de la moto
    public float maxSpeed = 20f; // Velocidad máxima hacia adelante
    public float maxReverseSpeed = 7f; // Velocidad máxima hacia atrás
    public float turnSpeed = 50f; // Velocidad de rotación
    public float brakePower = 0.2f; // Poder de frenado al cambiar de dirección
    public float tiltAngle = 15f; // Ángulo de inclinación máximo al girar

    private float currentSpeed = 0f; // Velocidad actual de la moto
    private Rigidbody rb;

    public float CurrentSpeed
    {
        get { return currentSpeed; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente RigidBody
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical"); // Entrada del jugador para adelante/atrás
        float turnInput = Input.GetAxis("Horizontal"); // Entrada para la rotación
        float turn = 0f; // Inicialmente, no hay rotación
        float tilt = 0f; // Inicialmente, no hay inclinación

        // Lógica de frenado y aceleración
        if (moveInput > 0)
        {
            // Si nos estamos moviendo hacia atrás, primero frenamos
            if (currentSpeed < 0)
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, brakePower * Time.deltaTime);
            }
            else
            {
                // Si no, aceleramos hacia adelante
                currentSpeed += acceleration * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed); // Limitar la velocidad máxima hacia adelante
            }
        }
        else if (moveInput < 0)
        {
            // Si nos estamos moviendo hacia adelante, primero frenamos
            if (currentSpeed > 0)
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, brakePower * Time.deltaTime);
            }
            else
            {
                // Si no, aceleramos hacia atrás
                currentSpeed -= acceleration * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, -maxReverseSpeed, 0f); // Limitar la velocidad máxima hacia atrás
            }
        }
        else
        {
            // Desaceleración gradual cuando no hay input
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, acceleration * Time.deltaTime);
        }

        // Solo permitir la rotación si la moto está en movimiento (aceleración hacia adelante o atrás)
        if (Mathf.Abs(currentSpeed) > 0.1f) // Si la velocidad es mayor que un valor mínimo
        {
            turn = turnInput * turnSpeed * Time.deltaTime;

            // Inclinación proporcional al giro
            tilt = -turnInput * tiltAngle; // Inclinación en el eje Z basada en la dirección de giro
        }

        // Aplicar el movimiento
        Vector3 moveDirection = transform.forward * currentSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        // Aplicar la rotación solo si hay velocidad
        transform.Rotate(0, turn, 0);

        // Aplicar la inclinación (tilt) en el eje Z
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, tilt);
    }
}

