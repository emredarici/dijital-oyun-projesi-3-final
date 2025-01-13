using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float lifetime = 2f;
    private float timer;
    private ProjectilePool pool;
    public GameEvent onScoreChanged;

    void OnEnable()
    {
        timer = 0f;
        pool = FindObjectOfType<ProjectilePool>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            DeactivateProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            onScoreChanged.RaiseEvent();
            DeactivateProjectile();
        }
    }

    void DeactivateProjectile()
    {
        gameObject.SetActive(false);
        pool.ReturnToPool(gameObject);
    }
}
