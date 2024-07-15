using System.Collections;
using Player;
using UnityEngine;

namespace Bullets
{
    //[RequireComponent(typeof(LineRenderer))]
    /*public class LaserBeam : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private float laserRayDistance = 10f;
        [SerializeField] private float laserDamageToEnemy = 2.5f;
        [SerializeField] private float laserWaitToDamageEnemy = 0.3f;
        public Transform laserOrigin;
        public LineRenderer lineRenderer;
        public Vector2 laserEndPoint;
        public Vector2 hitPoint;

        public bool facingRight;

        private Coroutine damageEnemyCoroutine;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            ShootLaser();
        }

        private void ShootLaser()
        {
            CheckLaserRight();
            CheckLaserLeft();
            DrawLaser();
        }

        private void CheckLaserRight()
        {
            if (facingRight)
            {
                var hit = Physics2D.Raycast(laserOrigin.position, transform.right, 20);
                if (hit.transform.CompareTag("Enemy"))
                {
                    EnemyHit(hit);
                }
                else if (hit.transform.CompareTag("Wall"))
                {
                    hitPoint = hit.point;
                }

                laserEndPoint = new Vector2(hitPoint.x, transform.position.y);
            }
        }

        private void CheckLaserLeft()
        {
            if (!facingRight)
            {
                var hit = Physics2D.Raycast(laserOrigin.position, transform.right, 20);
                if (hit)
                {
                    if (hit.transform.CompareTag("Enemy"))
                        EnemyHit(hit);
                    else if (hit.transform.CompareTag("Wall"))
                        hitPoint = hit.point;
                    else
                        hitPoint = new Vector2(-10, transform.position.y);
                }

                laserEndPoint = new Vector2(hitPoint.x, transform.position.y);
            }
        }

        private void EnemyHit(RaycastHit2D hit)
        {
            Debug.Log("Enemy tag found");
            hitPoint = hit.point;
            var enemy = hit.transform.GetComponent<Enemy.Enemy>();

            if (!enemy) return;

            Debug.Log("Enemy found");
            if (damageEnemyCoroutine == null)
                InitEnableDamageEnemyRoutine(enemy);
        }

        private void DrawLaser()
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, laserEndPoint);
        }

        public void CheckFacingRight(bool isFacingRight) => facingRight = isFacingRight;

        private IEnumerator LaserDamageEnemyRoutine(Enemy.Enemy enemyArg)
        {
            while (gameObject.activeInHierarchy)
            {
                enemyArg.Damage(laserDamageToEnemy);
                yield return new WaitForSeconds(laserWaitToDamageEnemy);
                Debug.Log("Enemy damaged from routine");
            }
        }

        private void InitEnableDamageEnemyRoutine(Enemy.Enemy enemyArg)
        {
            StopDamageEnemyRoutine();
            damageEnemyCoroutine = StartCoroutine(LaserDamageEnemyRoutine(enemyArg));
        }

        private void StopDamageEnemyRoutine()
        {
            if (damageEnemyCoroutine != null)
                StopCoroutine(damageEnemyCoroutine);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }*/
    [RequireComponent(typeof(LineRenderer))]
    public class LaserBeam : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private float laserRayDistance = 10f;
        [SerializeField] private float laserDamageToEnemy = 2.5f;
        [SerializeField] private float laserWaitToDamageEnemy = 0.3f;
        public Transform laserOrigin;
        public LineRenderer lineRenderer;
        public Vector2 laserEndPoint;
        public Vector2 hitPoint;

        public bool facingRight;

        private Coroutine damageEnemyCoroutine;
        private Enemy.Enemy currentEnemy;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            ShootLaser();
        }

        private void ShootLaser()
        {
            CheckLaserDirection();
            DrawLaser();
        }

        private void CheckLaserDirection()
        {
            var direction = facingRight ? Vector2.right : Vector2.left;
            var hit = Physics2D.Raycast(laserOrigin.position, direction, laserRayDistance);

            if (!hit) return;
            
            if (hit.transform.CompareTag("Enemy"))
            {
                HandleEnemyHit(hit);
            }
            else if (hit.transform.CompareTag("Wall"))
            {
                hitPoint = hit.point;
            }
            else
            {
                hitPoint = new Vector2(facingRight ? 10 : -10, transform.position.y);
            }

            laserEndPoint = new Vector2(hitPoint.x, transform.position.y);
        }

        private void HandleEnemyHit(RaycastHit2D hit)
        {
            Debug.Log("Enemy tag found");
            hitPoint = hit.point;
            var enemy = hit.transform.GetComponent<Enemy.Enemy>();

            if (enemy != currentEnemy)
            {
                currentEnemy = enemy;
                if (currentEnemy)
                {
                    InitEnableDamageEnemyRoutine(currentEnemy);
                }
            }
        }

        private void DrawLaser()
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, laserEndPoint);
        }

        public void CheckFacingRight(bool isFacingRight) => facingRight = isFacingRight;

        private IEnumerator LaserDamageEnemyRoutine(Enemy.Enemy enemyArg)
        {
            while (currentEnemy == enemyArg && gameObject.activeInHierarchy)
            {
                enemyArg.Damage(laserDamageToEnemy);
                yield return new WaitForSeconds(laserWaitToDamageEnemy);
                Debug.Log("Enemy damaged from routine");
            }
        }

        private void InitEnableDamageEnemyRoutine(Enemy.Enemy enemyArg)
        {
            StopDamageEnemyRoutine();
            damageEnemyCoroutine = StartCoroutine(LaserDamageEnemyRoutine(enemyArg));
        }

        private void StopDamageEnemyRoutine()
        {
            if (damageEnemyCoroutine == null) return;
            
            StopCoroutine(damageEnemyCoroutine);
            damageEnemyCoroutine = null;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            currentEnemy = null;
        }
    }
}