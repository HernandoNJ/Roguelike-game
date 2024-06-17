using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float nextFireTime = 2f;

    private void Start()
    {
        fireRate = GetComponent<Player>().fireRatio;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        // Instantiate bullet
        // Apply force
        var bullet =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var bulletSpeed = bullet.GetComponent<Bullet>().speed;
        var bulletDirection = GetComponent<PlayerInput>().GetPlayerAiming();
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletDirection * bulletSpeed, ForceMode2D.Impulse);
    }
}