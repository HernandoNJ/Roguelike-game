using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float nextFireTime = 0f;

    private Vector2 fireDirection;

    private void Start()
    {
        fireRate = GetComponent<Player>().projectileFireRate;
    }

    void Update()
    {
        fireDirection.x = Input.GetAxis("Horizontal");
        fireDirection.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot(fireDirection);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot(Vector2 direction)
    {
        // Calculate the angle based on the shooting direction
        //float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
        Vector3 projectileDirection = new Vector2(direction.x,direction.y);
        // Instantiate the projectile and set its rotation
        projectilePrefab.GetComponent<Projectile>().projectileMoveDirection = projectileDirection;
        Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(projectileDirection));
    }
}