using UI;
using UnityEngine;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private UIController uiController;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject laserPrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float fireRate = 2f;
        [SerializeField] private float maxFireRate = 5f;
        [SerializeField] private float nextFireTime = 2f;
        [SerializeField] private bool laserEnabled;
        
        private void Start()
        {
            fireRate = GetComponent<Player>().fireRatio;
        }

        private void Update()
        {
            if (Time.time >= nextFireTime)
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
            fireRate += amount;
            if (fireRate > maxFireRate) fireRate = maxFireRate;
        }

        public void EnableLaser()
        {
            laserEnabled = true;
            uiController.EnableLaserIcon(true);
        }

        public void ShootLaser()
        {
            if (laserEnabled) Debug.Log("Shooting laser code pending");
            
            // Disable icon after the laser has been used
            //uiController.EnableLaserIcon(false);
        }
    }
}