using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{

    [SerializeField] GameObject trigger; // El GameObject que queremos activar/desactivar
    bool isTriggerActive = false; // Inicialmente est� desactivado

    void Start()
    {
        // Asegurarte de que el trigger est� desactivado al inicio
        trigger.SetActive(isTriggerActive);
    }

    void Update()
    {
        // Aqu� puedes incluir l�gica adicional si es necesario
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("El jugador ha chocado con el trigger");
            isTriggerActive = true; // Cambiamos el estado a activo
            trigger.SetActive(isTriggerActive); // Activamos el GameObject
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("El jugador ha salido del trigger");
            isTriggerActive = false; // Cambiamos el estado a inactivo
            trigger.SetActive(isTriggerActive); // Desactivamos el GameObject
        }
    }
}
