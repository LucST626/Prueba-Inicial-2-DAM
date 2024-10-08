using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject canvasToHide;
    [SerializeField] GameObject canvasToHide2;
    [SerializeField] AudioSource musicSource;
    private bool isPaused = false; // Estado de pausa
   

    void Update()
    {
        // Detectar la pulsación de la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // Reanudar el juego
            }
            else
            {
                Pause(); // Pausar el juego
            }
        }
    }

    public void Resume()
    {
        canvasToHide.SetActive(true);
        canvasToHide2.SetActive(true);
        panel.SetActive(false);
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        isPaused = false; // Cambiar el estado a no pausado
        musicSource.Play();
        
    }

    public void Pause()
    {
        canvasToHide.SetActive(false);
        canvasToHide2.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 0f; // Detener el tiempo del juego
        isPaused = true; // Cambiar el estado a pausado
        musicSource.Pause();

    }

    public void LoadMenu() // Método para volver a la escena principal o a un menú específico
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo esté reanudado
        SceneManager.LoadScene("MenuInicial"); // Cambia "NombreDeTuEscena" por el nombre de tu escena
    }

    public void QuitGame() // Método para salir del juego
    {
        Application.Quit();
    }
}
