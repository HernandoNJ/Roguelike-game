using UnityEngine;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float fireRate = 2f;
        public float maxFireRate = 5f;
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
            // Instantiate bullet and apply force
            var bullet =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            var bulletSpeed = bullet.GetComponent<Bullet>().speed;
            var bulletDirection = GetComponent<PlayerMovement>().GetPlayerAiming();
            bullet.GetComponent<Rigidbody2D>().AddForce(bulletDirection * bulletSpeed, ForceMode2D.Impulse);
        }

        public void IncreaseFireRate(float amount)
        {
            Debug.Log("Curr Fire rate: " + fireRate);
            fireRate += amount;
            if (fireRate > maxFireRate) fireRate = maxFireRate;
            Debug.Log("New Fire rate: " + fireRate);
        }
    }
}