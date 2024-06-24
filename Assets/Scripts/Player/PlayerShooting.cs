using Bullets;
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
        [SerializeField] private float fireRate;
        [SerializeField] private float maxFireRate;
        [SerializeField] private float nextFireTime;
        [SerializeField] private bool laserEnabled;

        private void Start()
        {
            fireRate = GetComponent<Player>().fireRatio;
        }

        private void Update()
        {
            if (GetShootKeyPressed() && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }

        private void Shoot()
        {
            var bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            var bullet = bulletInstance.GetComponent<Bullet>();
            
            bullet.rb.AddForce(GetBulletDirection() * bullet.speed, ForceMode2D.Impulse);
        }

        private Vector2 GetBulletDirection()
        {
            var newBulletDirection = Vector2.zero;

            if (Input.GetKeyDown(KeyCode.UpArrow)) newBulletDirection = Vector2.up;
            else if (Input.GetKeyDown(KeyCode.DownArrow)) newBulletDirection = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) newBulletDirection = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow)) newBulletDirection = Vector2.right;

            return newBulletDirection;
        }

        private bool GetShootKeyPressed()
        {
            return Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                   Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow);
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