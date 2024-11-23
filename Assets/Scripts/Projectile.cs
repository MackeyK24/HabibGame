using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;

    void Start()
    {
        // Destroy the projectile after lifetime seconds
        Destroy(gameObject, lifetime);
    }

    void OnBecameInvisible()
    {
        // Destroy when it goes off screen
        Destroy(gameObject);
    }
}
