using Player;
using UnityEngine;

namespace Bullets
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserBeam : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private float laserRayDistance = 10f;
        public Transform laserOrigin;
        public LineRenderer lineRenderer;

        private Transform laserTransform;

        private void Awake()
        {
            laserTransform = GetComponent<Transform>();
            lineRenderer = GetComponent<LineRenderer>();
            gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            ShootLaser();
        }

        private void ShootLaser()
        {
            var playerFacingRight = playerMovement.GetFacingRight();
            var laserEndPoint = playerFacingRight ? Vector2.right : Vector2.left;

            RaycastHit2D hit = Physics2D.Raycast(laserOrigin.position, laserEndPoint);
            
            if (Physics2D.Raycast(laserOrigin.position, laserEndPoint))
            {
                lineRenderer.SetPosition(0, laserOrigin.position);

                if (hit.transform.CompareTag("Wall"))
                    lineRenderer.SetPosition(1, hit.point);
                else if (hit.transform.CompareTag("Enemy"))
                    lineRenderer.SetPosition(1, hit.point);
            }
        }
    }
}