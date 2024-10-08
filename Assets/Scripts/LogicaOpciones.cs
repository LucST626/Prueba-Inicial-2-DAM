using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOpciones : MonoBehaviour
{
    public ControladorOpciones panelOpciones;
    private bool isPaused = false; // Estado de pausa

    // Start is called before the first frame update
    void Start()
    {
        panelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorOpciones>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Reanudar el juego si est� pausado
            }
            else
            {
                MostrarOpciones(); // Mostrar las opciones y pausar el juego
            }
        }
    }

    public void MostrarOpciones()
    {
        panelOpciones.pantallaOpciones.SetActive(true); // Mostrar el panel de opciones
        Time.timeScale = 0f; // Pausar el juego
        isPaused = true; // Cambiar el estado a pausado
    }

    public void ResumeGame()
    {
        panelOpciones.pantallaOpciones.SetActive(false); // Ocultar el panel de opciones
        Time.timeScale = 1f; // Reanudar el juego
        isPaused = false; // Cambiar el estado a no pausado
    }
}
