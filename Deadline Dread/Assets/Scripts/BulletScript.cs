using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    private bool isDestroyed = false;

    void OnEnable()  // Use OnEnable instead of Start to reuse the bullet from the pool
    {
        bulletRB = GetComponent<Rigidbody2D>();

        // Reset the destroyed flag when the bullet is reused
        isDestroyed = false;

        // Check if Rigidbody2D is assigned
        if (bulletRB == null)
        {
            Debug.LogError("Rigidbody2D is missing on the bullet.");
        }

        target = GameObject.FindGameObjectWithTag("Player");

        // Check if target (Player) exists
        if (target != null)
        {
            Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        }
        else
        {
            bulletRB.velocity = transform.right * speed;  // Default direction
        }

        // Instead of destroying the bullet, we deactivate it after 2 seconds
        Invoke("DeactivateBullet", 2f);
    }

    void DeactivateBullet()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            gameObject.SetActive(false);  // Deactivate instead of destroying
        }
    }

    // Optional: Handle collisions
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            gameObject.SetActive(false);  // Deactivate instead of destroying
        }
    }
}
