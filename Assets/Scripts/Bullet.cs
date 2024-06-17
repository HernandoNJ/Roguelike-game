using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float size;
    public float damage;
    public float lifetime = 2f;
    
    public Rigidbody2D rb;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    //public void SetBulletSpeed(float newSpeed) => speed = newSpeed;

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     var shootableObj = other.GetComponent<IShootable>();
    //     shootableObj?.Shoot();
    //     // if other IDamageable, Damage(damage)
    //     Destroy(gameObject);
    // }
}
