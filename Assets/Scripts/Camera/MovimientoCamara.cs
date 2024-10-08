using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    [SerializeField] Transform target;                    // Objetivo al que seguir (personaje)
    Rigidbody2D targetRb;                                 // Rigidbody2D del objetivo
    [SerializeField] Vector3 offset = new Vector3(0, 0, -10);  // Desplazamiento de la cámara
    [SerializeField] float followSmooth = 0.3f;           // Suavidad del seguimiento horizontal
    [SerializeField] float verticalSmooth = 0.5f;         // Suavidad del seguimiento vertical (más lento que el horizontal)
    [SerializeField] float minSize = 5f;                  // Tamaño mínimo de la cámara
    [SerializeField] float maxSize = 8f;                  // Tamaño máximo de la cámara
    [SerializeField] float minZoomableSpeed = 1f;         // Velocidad mínima para aplicar zoom
    [SerializeField] float maxZoomableSpeed = 10f;        // Velocidad máxima para el zoom
    [SerializeField] float zoomSmooth = 0.1f;             // Suavidad del zoom
    [SerializeField] float lookAheadDistance = 2f;        // Distancia de anticipación al objetivo en horizontal
    [SerializeField] float verticalLookAheadLimit = 1f;   // Límite de anticipación en vertical para evitar movimientos bruscos
    [SerializeField] float lookAheadSmooth = 0.1f;        // Suavidad de la anticipación
    new Camera camera;

    Vector3 positionVelocity = Vector3.zero;              // Velocidad del seguimiento de posición
    Vector3 lookAheadVelocity = Vector3.zero;             // Velocidad del "look ahead"
    float sizeVelocity = 0f;                              // Velocidad del zoom
    Vector3 lookAhead;                                    // Vector de anticipación
    float targetSpeed;                                    // Velocidad actual del personaje
    float normalizedSpeed;                                // Velocidad normalizada para el zoom
    float targetSize;                                     // Tamaño objetivo de la cámara

    private void Awake()
    {
        // Inicializar posiciones y referencias
        transform.position = target.position + offset;
        targetRb = target.GetComponent<Rigidbody2D>();
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        // Ajuste de anticipación según la velocidad del personaje (solo en horizontal)
        if (targetRb.velocity.magnitude > 0)
        {
            Vector2 targetVelocity = targetRb.velocity;
            // Solo anticipar en horizontal, limitar la anticipación vertical
            lookAhead = Vector3.SmoothDamp(
                lookAhead,
                new Vector3(targetVelocity.x, 0, 0) * lookAheadDistance,
                ref lookAheadVelocity,
                lookAheadSmooth
            );
        }

        // Ajuste de la posición de la cámara, separando el suavizado horizontal y vertical
        Vector3 targetPosition = new Vector3(
            Mathf.SmoothDamp(transform.position.x, target.position.x + offset.x + lookAhead.x, ref positionVelocity.x, followSmooth),
            Mathf.SmoothDamp(transform.position.y, target.position.y + offset.y, ref positionVelocity.y, verticalSmooth), // Suavidad vertical distinta
            offset.z
        );

        transform.position = targetPosition;

        // Cálculo del zoom basado en la velocidad del personaje
        targetSpeed = targetRb.velocity.magnitude;
        normalizedSpeed = Mathf.Clamp01((targetSpeed - minZoomableSpeed) / (maxZoomableSpeed - minZoomableSpeed));
        targetSize = normalizedSpeed * (maxSize - minSize) + minSize;

        // Ajuste suave del tamaño de la cámara
        camera.orthographicSize = Mathf.SmoothDamp(
            camera.orthographicSize,
            targetSize,
            ref sizeVelocity,
            zoomSmooth
        );
    }
}
