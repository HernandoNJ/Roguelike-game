using System;
using UnityEngine;

namespace Bullets
{
    public class LaserBeam : MonoBehaviour
    {
        [SerializeField] private float laserRayDistance = 10f;
        public Transform laserFirePoint;
        public LineRenderer lineRenderer;

        private Transform laserTransform;

        private void Awake()
        {
            laserTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            ShootLaser();
        }

        public void ShootLaser()
        {
            if (Physics2D.Raycast(laserTransform.position, transform.right))
            {
                var hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
                
                DrawLaserBeamLine(laserFirePoint.position, hit.point);
            }
            else
            {
                DrawLaserBeamLine(laserFirePoint.position, laserFirePoint.transform.right * laserRayDistance);
            }
        }

        private void DrawLaserBeamLine(Vector2 startPos, Vector2 endPos)
        {
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);
        }

        private void CheckEnemy(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Enemy found. name: " + other.gameObject.name);
                var enemy = other.GetComponent<Enemy.Enemy>();

                if (enemy != null)
                {
                    Debug.Log("Enemy script = " + enemy.name);
                    enemy.Damage(0.1f);
                }
            }
        }
    }
}