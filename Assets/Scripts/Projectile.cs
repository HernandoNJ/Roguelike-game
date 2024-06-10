using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Player player;
    public Vector2 projectileMoveDirection;
    public float speed;
    public float size;
    public float damage;
    public float lifetime = 2f;
    
    private Rigidbody2D rb;

    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        speed = player.bulletSpeed;
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = projectileMoveDirection * speed;

        Destroy(gameObject, lifetime);
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     var shootableObj = other.GetComponent<IShootable>();
    //     shootableObj?.Shoot();
    //     // if other IDamageable, Damage(damage)
    //     Destroy(gameObject);
    // }
}
