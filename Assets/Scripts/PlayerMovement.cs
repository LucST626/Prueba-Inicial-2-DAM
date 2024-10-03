using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento horizontal
    public float jumpForce = 10f; // Fuerza de salto
    private Rigidbody2D rb;       // Referencia al Rigidbody2D del jugador
    private bool isGrounded;      // Para saber si el jugador está en el suelo

    // LayerMask para definir qué es suelo
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    void Start()
    {
        // Obtiene el componente Rigidbody2D en el inicio
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal usando las teclas A (izquierda) y D (derecha)
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // Movimiento hacia la izquierda
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);  // Movimiento hacia la derecha
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Detener movimiento horizontal si no se presiona A o D
        }

        // Verificación si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Salto con la tecla W
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplicar fuerza hacia arriba para saltar
        }
    }
}
