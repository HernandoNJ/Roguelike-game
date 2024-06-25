using System.Collections;
using Bullets;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject laserPrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float fireRate;
        [SerializeField] private float maxFireRate;
        public float nextFireTime;

        public UnityEvent onLaserEnabled;
        public UnityEvent onLaserActivated;

        private Coroutine laserRoutine;

        // public for testing
        // turn into private later
        [SerializeField] private float laserWaitTime;
        [SerializeField] private float timeToEnableLaser;
        public float spaceKeyPressedTime;
        public bool isLaserEnabled;
        public bool shootLaserEnabled;

        private void Start()
        {
            fireRate = GetComponent<Player>().fireRatio;
        }

        private void Update()
        {
            CheckShootKeyPressed();
            CheckLaserKeyPressed();
        }

        private void CheckShootKeyPressed()
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
            if (Input.GetKeyDown(KeyCode.UpArrow)) return Vector2.up;
            if (Input.GetKeyDown(KeyCode.DownArrow)) return Vector2.down;
            if (Input.GetKeyDown(KeyCode.LeftArrow)) return Vector2.left;
            if (Input.GetKeyDown(KeyCode.RightArrow)) return Vector2.right;
            return Vector2.zero;
        }

        private bool GetShootKeyPressed()
        {
            return Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                   Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow);
        }

        public void IncreaseFireRate(float amount)
            => fireRate = Mathf.Min(fireRate + amount, maxFireRate);

        private void CheckLaserKeyPressed()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // if isLaserEnabled is false, add time
                if (!isLaserEnabled)
                {
                    spaceKeyPressedTime += Time.deltaTime;

                    if (spaceKeyPressedTime >= timeToEnableLaser)
                        EnableLaser();
                }
                
                if (isLaserEnabled && shootLaserEnabled)
                    onLaserActivated?.Invoke();
            }
            // if space bar is not pressed and the condition is met
            // reset spaceKeyPressedTime
            else if (spaceKeyPressedTime <= timeToEnableLaser)
                spaceKeyPressedTime = 0;
        }

        private void EnableLaser()
        {
            isLaserEnabled = true;
            InitLaserWaiter();
        }
        
        private void ResetLaser()
        {
            spaceKeyPressedTime = 0;
            isLaserEnabled = false;
            shootLaserEnabled = false;

            ResetLaserWaiter();
        }

        private void InitLaserWaiter()
        {
            if (laserRoutine != null) 
                StopCoroutine(laserRoutine);
            
            laserRoutine = StartCoroutine(EnableShootLaserRoutine());
        }

        private void ResetLaserWaiter()
        {
            if (laserRoutine != null)
            {
                StopCoroutine(laserRoutine);
                laserRoutine = null;
            }
        }
        
        public void ShootLaser()
        {
            Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
            ResetLaser();
        }

        private IEnumerator EnableShootLaserRoutine()
        {
            yield return new WaitForSeconds(laserWaitTime);
            onLaserEnabled?.Invoke();
            shootLaserEnabled = true;
        }
    }
}