using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bullets
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserBeam : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private float laserRayDistance = 10f;
        public Transform laserOrigin;
        public LineRenderer lineRenderer;
        public Vector2 laserEndPoint;
        public Vector2 hitPoint;

        public bool facingRight;

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
            if (facingRight)
            {
                var hit = Physics2D.Raycast(laserOrigin.position, transform.right, 20);
                if (hit)
                {
                    if (hit.transform.CompareTag("Enemy") ||
                        hit.transform.CompareTag("Wall"))
                    {
                        hitPoint = hit.point;
                    }
                }
                else hitPoint = new Vector2(10, transform.position.y);

                laserEndPoint = new Vector2(hitPoint.x, transform.position.y);
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, laserEndPoint);
            }

            if (!facingRight)
            {
                var hit = Physics2D.Raycast(laserOrigin.position, transform.right, 20);
                if (hit)
                {
                    if (hit.transform.CompareTag("Enemy") ||
                        hit.transform.CompareTag("Wall"))
                    {
                        hitPoint = hit.point;
                    }
                    else hitPoint = new Vector2(-10, transform.position.y);
                }

                laserEndPoint = new Vector2(hitPoint.x, transform.position.y);
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, laserEndPoint);
            }
        }

        public void CheckFacingRight(bool isFacingRight) => facingRight = isFacingRight;
    }
}