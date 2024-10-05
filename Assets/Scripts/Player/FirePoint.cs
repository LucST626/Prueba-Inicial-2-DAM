using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public Transform player; // Asigna el transform del jugador en el Inspector
    public float distanceFromPlayer = 1f; // Distancia deseada desde el jugador
    public float rotationSpeed = 5f; // Velocidad de rotación de la "arma"

    void Update()
    {
        MouseMovementProcess();
    }

    void MouseMovementProcess()
    {
        // Obtener la posición del ratón en el mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Asegúrate de que la Z sea cero para 2D

        // Calcular la dirección hacia el ratón pero mantener la altura del jugador
        Vector3 targetDir = (new Vector3(mousePos.x, player.position.y, 0) - player.position).normalized;

        // Calcular la nueva posición de la "arma" alrededor del jugador
        Vector3 desiredPosition = player.position + targetDir * distanceFromPlayer;

        // Mover la "arma" hacia la posición deseada
        transform.position = Vector3.Lerp(transform.position, desiredPosition, rotationSpeed * Time.deltaTime);

        // Calcular el ángulo de rotación y aplicarlo
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
