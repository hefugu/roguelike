using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;

    Rigidbody2D rb;
    Vector2 move;

    public GameObject bulletPrefab;
    public float shootInterval = 0.6f;

    float shootTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move = move.normalized;

        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = move * speed;
    }

    void Shoot()
    {
        GameObject nearest = FindNearestEnemy();

        if (nearest == null)
            return;

        Vector2 dir = (nearest.transform.position - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().direction = dir;
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDist = Mathf.Infinity;
        GameObject nearest = null;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }
}