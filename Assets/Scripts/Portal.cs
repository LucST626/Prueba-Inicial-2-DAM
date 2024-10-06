using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public float levitationSpeed = 1f;    // Velocidad de la levitación
    public float levitationHeight = 0.5f; // Altura máxima de la levitación
    public float rotationSpeed = 50f;     // Velocidad de rotación
    public string nextSceneName;          // Nombre de la siguiente escena

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;  // Guardamos la posición inicial
    }

    private void Update()
    {
        // Movimiento de levitación
        float newY = startPos.y + Mathf.Sin(Time.time * levitationSpeed) * levitationHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Rotación sobre su propio eje
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el jugador ha tocado el portal
        if (other.CompareTag("Player"))
        {
            // Cambiar a la siguiente escena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
