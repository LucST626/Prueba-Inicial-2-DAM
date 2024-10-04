using UnityEngine;

public class Tomahawk : MonoBehaviour
{
    // Destruir al colisionar con el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si ha colisionado con el suelo usando el layer del suelo
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            //Destroy(gameObject); // Destruir el tomahawk
        }
    }
}
