using System.Collections;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] public float jumpForce = 10f;          // Fuerza de salto
   // [SerializeField] Animator animator;                     // Animator del jugador
    [SerializeField] ParticleSystem jumpParticle;           // Efecto de partículas al saltar
    private bool canJump;                                   // Controla si el jugador puede saltar

    [Header("Ground")]
    [SerializeField] Transform groundCheckPoint;            // Punto para verificar si toca el suelo
    [SerializeField] LayerMask GroundLayer;                 // Capa de suelo para la detección
    [SerializeField] float distanceToGround = 1f;           // Distancia al suelo para verificar si está en el aire
    private Rigidbody2D rb;                                 // Referencia al Rigidbody2D

    [Header("Movement")]
    [SerializeField] public float moveSpeed = 5f;           // Velocidad de movimiento
    [SerializeField] public float friccion = 0.95f;         // Fricción para desacelerar cuando no hay input

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();                // Asignamos el Animator
       // animator.SetBool("isJumping", false);
    }

    private void Update()
    {
        // Movimiento horizontal
        Vector2 movementInput = Vector2.zero;
        if (Input.GetKey(KeyCode.D))
            movementInput.x = 1;
        else if (Input.GetKey(KeyCode.A))
            movementInput.x = -1;

        // Chequear si está en el suelo
        bool isGrounded = IsGrounded();

        // Si está en el suelo, permitimos el salto
        if (isGrounded)
        {
            canJump = true;
            //animator.SetBool("isJumping", false);
        }

        // Manejo del salto
        if (Input.GetKeyDown(KeyCode.Space) && canJump && isGrounded)
        {
            Jump();
        }

        // Movimiento horizontal con Rigidbody
        if (movementInput.x != 0)
        {
            Move(movementInput.x);
        }
        else
        {
            // Aplicamos fricción para reducir la velocidad cuando no hay input
            rb.velocity = new Vector2(rb.velocity.x * friccion, rb.velocity.y);
        }
    }

    private void Move(float direction)
    {
        // Movimiento horizontal
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        // Aplicar fuerza de salto
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        canJump = false;  // Desactivamos el salto hasta que vuelva a tocar el suelo
      //  animator.SetBool("isJumping", true);
        jumpParticle.Play();  // Activar las partículas de salto
    }

    // Verificar si el personaje está tocando el suelo
    private bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheckPoint.position, Vector2.down, distanceToGround, GroundLayer);
    }
}
