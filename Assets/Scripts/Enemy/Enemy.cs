using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        private enum EnemyState
        {
            Block,
            Attack,
            Die
        }

        [SerializeField] private EnemyState enemyState = EnemyState.Attack;
        [SerializeField] private Transform player;
        [SerializeField] private GameObject enemyWall;
        [SerializeField] private GameObject enemyBullet;
        [SerializeField] private float health = 10;
        [SerializeField] private float checkStateTimer = 0.2f;
        [SerializeField] private float bulletSpeed = 3f;
        [SerializeField] private float fireRate = 0.2f;
        [SerializeField] private float nextFireTime = 0.1f;
        [SerializeField] private float shootingRange = 2f;
        [SerializeField] private bool isDamageable;

        public float moveBackDistance = 1f;
        public float moveBackTime = 0.2f;
        public float returnTime = 0.3f;
        private Vector3 originalPosition;

        private void Start()
        {
            originalPosition = transform.position;
            player = FindObjectOfType<Player.Player>().GetComponent<Transform>();
            enemyWall.SetActive(true);
            InvokeRepeating(nameof(CheckEnemyState), 0.1f, checkStateTimer);
        }

        private void CheckEnemyState()
        {
            if (player == null) return;
            
            var distance = Vector2.Distance(transform.position, player.position);

            if (distance <= shootingRange && Time.time >= nextFireTime)
            {
                enemyState = EnemyState.Attack;
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
            else
            {
                enemyState = EnemyState.Block;
                Block();
            }
        }

        private void Shoot()
        {
            // Direction from enemy to player
            Vector2 directionToPlayer = (player.position - transform.position).normalized;

            // Instantiate and shoot the bullet towards the player
            ShootBullets(directionToPlayer);

            // Calculate direction for +15 degrees
            Vector2 directionPlus15 = Quaternion.Euler(0, 0, 15) * directionToPlayer;
            ShootBullets(directionPlus15);

            // Calculate direction for -15 degrees
            Vector2 directionMinus15 = Quaternion.Euler(0, 0, -15) * directionToPlayer;
            ShootBullets(directionMinus15);
        }

        private void Block()
        {
            enemyWall.SetActive(true);
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void ShootBullets(Vector2 direction)
        {
            // Instantiate the bullet at the enemy's position
            GameObject bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Apply force to the bullet in the calculated direction
            rb.velocity = direction * bulletSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerBullet"))
            {
                var otherPosition = other.transform.position;
                ShockEnemy(otherPosition);
            }
        }

        private void ShockEnemy(Vector3 otherPosition)
        {
            
            // Calculate the direction from the bullet to the enemy
            var hitDirection = transform.position - otherPosition;

            // Calculate the move back position in the opposite direction of the hit
            var moveBackPosition = transform.position + hitDirection * moveBackDistance;

            StartCoroutine(MoveToPosition(
                moveBackPosition,
                moveBackTime,
                () => { StartCoroutine(MoveToPosition(originalPosition, returnTime)); }));
        }

        private IEnumerator MoveToPosition(Vector3 targetPosition, float duration, Action onComplete = null)
        {
            float elapsedTime = 0;
            var startingPosition = transform.position;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;

            onComplete?.Invoke();
        }
    }
}