using System.Collections;
using Bullets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(LineRenderer))]
    public class PlayerShooting : MonoBehaviour
    {
        [Header("Bullet")] [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float fireRate;
        [SerializeField] private float maxFireRate;
        [SerializeField] private float nextFireTime;

        [Header("Laser")] [SerializeField] private GameObject laserPrefab;
        [SerializeField] private Transform laserTarget;
        [SerializeField] private Transform laserFirePoint;
        [SerializeField] private float laserKeyTimer;
        [SerializeField] private float laserKeyPressedTime;
        [SerializeField] private float activateLaserWait;
        [SerializeField] private float laserActiveTime;
        [SerializeField] private float laserDuration;
        [SerializeField] private bool shootLaserEnabled;

        // public Transform laserOrigin;
        // public float laserRange = 3f;
        // public float laserDuration = 3f;
        // public LineRenderer laserLine;

        public UnityEvent onLaserEnabled;
        public UnityEvent onLaserActivated;
        public UnityEvent onLaserDisabled;

        private Coroutine enableLaserCoroutine;

        private void Start()
        {
            fireRate = GetComponent<Player>().GetPlayerFireRatio();
            //laserLine = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            CheckShootKeyPressed();
            CheckLaserShooting();
            CheckLaserEnabledTimer();
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

        // Check both if laser key is pressed and laser timer value
        private void CheckLaserShooting()
        {
            var laserTimeReached = laserKeyPressedTime >= laserKeyTimer;

            // If holding space but time not reached, add time
            // If time reached, init routine
            if (Input.GetKey(KeyCode.Space))
            {
                if (!laserTimeReached)
                    laserKeyPressedTime += Time.deltaTime;
                else
                    InitEnableLaserRoutine();
            }

            // if conditions are met, raise onLaserActivated
            if (Input.GetKeyDown(KeyCode.Space)
                && laserTimeReached
                && shootLaserEnabled)
            {
                onLaserActivated?.Invoke();
            }

            // if releasing space and time not reached, reset the time
            if (Input.GetKeyUp(KeyCode.Space) && !laserTimeReached)
            {
                laserKeyPressedTime = 0;
            }
        }

        public void ResetLaser()
        {
            laserKeyPressedTime = 0;

            if (enableLaserCoroutine != null)
            {
                StopCoroutine(enableLaserCoroutine);
                enableLaserCoroutine = null;
            }
        }

        private void CheckLaserEnabledTimer()
        {
            if (shootLaserEnabled)
            {
                laserActiveTime += Time.deltaTime;

                if (laserActiveTime >= laserDuration)
                {
                    shootLaserEnabled = false;
                    laserActiveTime = 0;
                    onLaserDisabled?.Invoke();
                }
            }
        }

        private void InitEnableLaserRoutine()
        {
            if (enableLaserCoroutine != null)
                StopCoroutine(enableLaserCoroutine);

            enableLaserCoroutine = StartCoroutine(EnableLaserRoutine());
        }

        private IEnumerator EnableLaserRoutine()
        {
            yield return new WaitForSeconds(activateLaserWait);
            onLaserEnabled?.Invoke();
            shootLaserEnabled = true;
        }
    }
}