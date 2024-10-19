using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleRadio : MonoBehaviour
{
    public AudioSource radioAudioSource; // AudioSource para la radio
    public AudioClip[] songs; // Lista de canciones (10 canciones)
    private int currentSongIndex = 0; // Índice de la canción actual
    public float fadeDuration = 1.0f; // Duración del fade-out y fade-in

    void Start()
    {
        // Inicializar la primera canción y reproducirla
        if (songs.Length > 0)
        {
            radioAudioSource.clip = songs[currentSongIndex];
            radioAudioSource.Play();
        }
    }

    void Update()
    {
        // Verificar si la canción actual ha terminado para reproducir la siguiente
        if (!radioAudioSource.isPlaying)
        {
            StartCoroutine(FadeOutAndNextSong(fadeDuration)); // Iniciar el fade-out cuando la canción termine
        }

        // Cambiar de canción cuando el jugador presiona la tecla 'R'
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(FadeOutAndNextSong(fadeDuration)); // Iniciar el fade-out al presionar 'R'
        }
    }

    // Función para reproducir la siguiente canción
    void PlayNextSong()
    {
        currentSongIndex = (currentSongIndex + 1) % songs.Length; // Pasar a la siguiente canción en bucle
        radioAudioSource.clip = songs[currentSongIndex];
        radioAudioSource.Play();
    }

    // Coroutine para reducir gradualmente el volumen y pasar a la siguiente canción
    IEnumerator FadeOutAndNextSong(float fadeDuration)
    {
        // Reducir gradualmente el volumen (fade-out)
        while (radioAudioSource.volume > 0)
        {
            radioAudioSource.volume -= Time.deltaTime / fadeDuration;
            yield return null;
        }

        PlayNextSong(); // Reproducir la siguiente canción

        // Configurar el volumen a 0 antes de hacer el fade-in
        radioAudioSource.volume = 0f;

        // Aumentar gradualmente el volumen (fade-in)
        while (radioAudioSource.volume < 0.2f)
        {
            radioAudioSource.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }
    }
}
