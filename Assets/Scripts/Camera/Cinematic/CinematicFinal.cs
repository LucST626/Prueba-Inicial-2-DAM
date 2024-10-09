using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class CinematicFinal : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // El VideoPlayer asignado desde el Inspector
    public Button skipButton;  // El botón de skip asignado desde el Inspector

    void Start()
    {
        // Asegurarse de que el VideoPlayer está inicializado
        videoPlayer.loopPointReached += OnVideoFinished; // Evento cuando el video termine

        // Agregar la funcionalidad al botón de skip
        skipButton.onClick.AddListener(SkipWithButton);
    }

    // Este método será llamado cuando termine el video
    void OnVideoFinished(VideoPlayer vp)
    {
        // Cargar la escena de menú inicial
        SceneManager.LoadScene("MenuInicial");
    }

    // Método para saltar con el botón de la UI
    public void SkipWithButton()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    // Método para saltar con la tecla 'E' (opcional)
    public void Skip()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MenuInicial");
        }
    }
}
