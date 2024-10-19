using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotocycleSound : MonoBehaviour
{
    public AudioSource motorAudioSource; // Referencia al AudioSource
    public AudioClip motorSound; // Sonido del motor
    public float minPitch = 0.8f; // Pitch mínimo para sonido lento
    public float maxPitch = 2.0f; // Pitch máximo para sonido rápido

    private MotorcycleController motoMovement; // Referencia al script de movimiento

    void Start()
    {
        // Obtener el componente de movimiento de la moto
        motoMovement = GetComponent<MotorcycleController>();

        // Configurar el AudioSource
        motorAudioSource.clip = motorSound;
        motorAudioSource.loop = true; // Hacer que el sonido sea un loop
        motorAudioSource.Play(); // Reproducir el sonido de inmediato
    }

    void Update()
    {
        // Cambiar el pitch del sonido según la velocidad actual de la moto
        float speed = Mathf.Abs(motoMovement.CurrentSpeed); // Tomar la velocidad absoluta desde la propiedad
        float pitch = Mathf.Lerp(minPitch, maxPitch, speed / motoMovement.maxSpeed); // Interpolar el pitch según la velocidad

        motorAudioSource.pitch = pitch; // Aplicar el nuevo pitch
    }
}
