using UnityEngine;

public class Tomahawk : MonoBehaviour
{
    [Header("Rotaci�n")]
    public float rotationSpeed = -200f; // Velocidad de rotaci�n en grados por segundo

    private void Update()
    {
        // Aplicar rotaci�n constante
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    // Destruir al colisionar con el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si ha colisionado con el suelo usando el layer del suelo
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject); // Destruir el tomahawk
        }
    }
}
