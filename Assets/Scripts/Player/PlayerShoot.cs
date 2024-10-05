using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint;     // Punto desde donde se disparará la bala
    public float bulletSpeed = 20f; // Velocidad de la bala

    [Header("Cooldown")]
    public float cooldown = 1f; // Duración del cooldown
    private float elapsedCooldown = 0f; // El tiempo que transcurre desde que se lanza
    private bool isCooldown = false; // Comprueba si el cooldown está activo

    [Header("Animación")]
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Si se hace clic con el botón izquierdo del ratón y no hay cooldown activo
        if (Input.GetMouseButtonDown(0) && !isCooldown)
        {
            Shoot();
            isCooldown = true;         // Activar cooldown
            elapsedCooldown = 0f;      // Reiniciar el contador de cooldown
        }

        // Incrementa el tiempo transcurrido durante el cooldown
        if (isCooldown)
        {
            elapsedCooldown += Time.deltaTime;

            // Si el tiempo transcurrido supera la duración del cooldown, desactiva el cooldown
            if (elapsedCooldown >= cooldown)
            {
                isCooldown = false;
            }
        }
    }

    void Shoot()
    {
        // Activar la animación de ataque
        animator.SetTrigger("Attack");

        // Crear la bala en el firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Obtener la dirección hacia el ratón
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Asegurarse de que la bala se mantenga en el plano 2D
        Vector2 direction = (mousePosition - firePoint.position).normalized;

        // Aplicar movimiento a la bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
        rb.gravityScale = 1; // Añadir gravedad realista

        // Destruir la bala después de 2 segundos
        Destroy(bullet, 2f);
    }
}
