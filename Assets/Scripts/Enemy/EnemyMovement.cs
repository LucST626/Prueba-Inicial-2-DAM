using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;  // Velocidad del enemigo
    public float detectionRange = 5f;  // Distancia a la que el enemigo detecta al jugador

    [Header("Player Detection")]
    public Transform player;  // Referencia al jugador
    private bool playerInRange = false;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheckPoint;  // Punto para verificar el suelo
    [SerializeField] LayerMask groundLayer;  // Capa del suelo
    [SerializeField] float groundCheckDistance = 1f;  // Distancia para verificar si hay suelo debajo

    private Rigidbody2D rb;
    private bool facingRight = true;  // Control para la dirección del enemigo

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Verificamos la distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }

        if (playerInRange)
        {
            FollowPlayer();
        }

        // Verificamos si el enemigo está sobre el suelo
        if (!IsGrounded())
        {
            // Si no hay suelo, podemos hacer que el enemigo se detenga o haga algo
            StopMoving();
        }
    }

    private void FollowPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        // Voltear el enemigo hacia el jugador
        if ((direction.x > 0 && !facingRight) || (direction.x < 0 && facingRight))
        {
            Flip();
        }
    }

    private void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar el rango de detección en la escena
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
