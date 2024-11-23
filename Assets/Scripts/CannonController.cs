using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float minAngle = 0f;
    public float maxAngle = 90f;
    public float maxPower = 20f;
    public GameObject projectilePrefab;

    private float currentAngle = 45f;
    private float currentPower = 10f;

    void Update()
    {
        // Get mouse position for aiming
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Clamp angle between min and max values
        currentAngle = Mathf.Clamp(angle, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);

        // Adjust power with mouse wheel
        currentPower += Input.GetAxis("Mouse ScrollWheel") * 5f;
        currentPower = Mathf.Clamp(currentPower, 0, maxPower);

        // Fire on left click
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Calculate direction from angle
        Vector2 direction = Quaternion.Euler(0, 0, currentAngle) * Vector2.right;

        // Apply force
        rb.AddForce(direction * currentPower, ForceMode2D.Impulse);
    }
}
