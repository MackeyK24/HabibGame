using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 1;
    public GameObject hitEffect;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Add score
            if (gameManager != null)
            {
                gameManager.AddCredits(scoreValue);
            }

            // Show hit effect
            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }

            // Destroy the projectile
            Destroy(collision.gameObject);
        }
    }
}
