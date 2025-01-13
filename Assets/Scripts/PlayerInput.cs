using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Transform firePoint;
    public ProjectilePool projectilePool;
    public float projectileSpeed = 10f;
    private Rigidbody2D rb2;
    public GameEvent fireEvent;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - rb2.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            Fire(mousePosition);
        }
    }

    void Fire(Vector3 targetPosition)
    {
        if (firePoint == null) Debug.LogError("firePoint is null!");
        if (projectilePool == null) Debug.LogError("projectilePool is null!");
        if (fireEvent == null) Debug.LogError("fireEvent is null!");


        GameObject projectile = projectilePool.GetProjectile();
        if (projectile != null)
        {
            projectile.transform.position = firePoint.position;
            projectile.SetActive(true);

            Vector3 direction = (targetPosition - firePoint.position).normalized;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
            ;
        }
    }
}
