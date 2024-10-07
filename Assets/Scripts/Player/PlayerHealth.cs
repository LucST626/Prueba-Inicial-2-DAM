using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;  // Vida m�xima del jugador
    private int currentHealth;

    [Header("UI")]
    public Slider healthBar;  // Referencia a la barra de vida (Slider)
    public Image fillImage;  // Imagen del Slider que cambia de color

    [Header("Audio")]
    public AudioClip damageSound; // Clip de sonido para cuando recibe da�o
    private AudioSource audioSource; // Componente AudioSource

    private void Start()
    {
        currentHealth = maxHealth;  // Inicializar la salud
        healthBar.maxValue = maxHealth;  // Asignar el valor m�ximo al slider
        healthBar.value = currentHealth;  // Establecer el valor inicial del slider
        UpdateHealthBarColor();

        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Llamado cuando el jugador recibe da�o
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;  // Actualizar la barra de vida
        UpdateHealthBarColor();  // Actualizar el color de la barra de vida

        // Reproducir el sonido de da�o
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�todo para curar al jugador
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        // No exceder la vida m�xima
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.value = currentHealth;  // Actualizar la barra de vida
        UpdateHealthBarColor();  // Actualizar el color de la barra de vida
    }

    // M�todo para reiniciar la escena cuando el jugador muere
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Cambiar el color de la barra de vida seg�n la salud restante
    private void UpdateHealthBarColor()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        Color healthColor = Color.Lerp(Color.red, Color.green, healthPercentage);
        fillImage.color = healthColor;
    }

    // Si el jugador colisiona con un enemigo, toma da�o
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);  // Recibe 1 de da�o por cada colisi�n
        }
    }
}
