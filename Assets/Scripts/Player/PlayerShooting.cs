using System.Collections;
using Bullets;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject laserPrefab;
        [SerializeField] private Transform laserTarget;
        [SerializeField] private Transform laserFirePoint;
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
        [SerializeField] private float spaceKeyPressedTime;
        [SerializeField] private bool isLaserEnabled;
        [SerializeField] private bool shootLaserEnabled;

        private void Start()
        {
            fireRate = GetComponent<Player>().GetPlayerFireRatio();
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
            // issues
            // Laser is done from 0.0.0
            
            // Calculate the direction and distance from playerFirePosition to the fire object
            var direction = laserTarget.position - GameManager.Instance.GetPlayerPosition;
            var distance = direction.magnitude;
            Debug.Log("direction magnitude: " + direction.magnitude);

            // Instantiate the laser at the playerFirePosition
            var laser = Instantiate(laserPrefab, laserFirePoint.position, Quaternion.identity);

            // Get the BoxCollider2D from the laser
            var laserBoxCollider = laser.GetComponent<BoxCollider2D>();
            var laserWidth = laserBoxCollider.size.x;
            Debug.Log("Laser width: " + laserWidth);
            
            
            // Get the SpriteRenderer component from the laser
            var spriteRenderer = laser.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                // Calculate the bottom-left position of the sprite in local space
                var laserBottomLeft = spriteRenderer.bounds.min - laser.transform.position;

                // Move the laser so that its bottom-left corner aligns with the playerFirePosition
                laser.transform.position = laserFirePoint.position - laserBottomLeft;

                // Adjust the laser's scale and rotation to stretch to the fire object
                laser.transform.right = direction.normalized; // Set the laser's direction
                laser.transform.localScale = new Vector3(distance, laser.transform.localScale.y, laser.transform.localScale.z); // Scale the laser's length
            }
            else
            {
                Debug.LogError("No SpriteRenderer found on the laserPrefab.");
            }
            
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