using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CinematicScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // El VideoPlayer asignado desde el Inspector
    //public string gameplaySceneName; // Nombre de la escena de gameplay

    void Start()
    {
        // Asegurarse de que el VideoPlayer está inicializado
        videoPlayer.loopPointReached += OnVideoFinished; // Evento cuando el video termine
    }

    private void Update()
    {
        Skip();
    }

    // Este método será llamado cuando termine el video
    void OnVideoFinished(VideoPlayer vp)
    {
        // Cargar la escena de gameplay
        SceneManager.LoadScene("Tutorial");
    }

    public void Skip()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Tutorial");

        }
    }
}
