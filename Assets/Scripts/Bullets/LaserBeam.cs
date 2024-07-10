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
        public Vector2 laserEndPoint;
        public Vector2 hitPoint;
        public bool facingRight;

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
            facingRight = playerMovement.GetFacingRight();
            laserEndPoint = facingRight ? Vector2.right : Vector2.left;

            RaycastHit2D hit = Physics2D.Raycast(laserOrigin.position, laserEndPoint);
            
            if (Physics2D.Raycast(laserOrigin.position, laserEndPoint))
            {
                lineRenderer.SetPosition(0, laserOrigin.position);

                hitPoint = hit.point;
                
                if (hit.transform.CompareTag("Wall"))
                    lineRenderer.SetPosition(1, hitPoint);
                else if (hit.transform.CompareTag("Enemy"))
                    lineRenderer.SetPosition(1, hitPoint);
            }
        }
        
        void OnDrawGizmos()
        {
            // Set the desired color for the ray (optional)
            Gizmos.color = Color.yellow;

            // Define the start position of the ray (usually transform.position)
            Vector3 startPoint = laserOrigin.position;

            // Define the direction of the ray (often transform.forward)
            Vector3 direction = laserEndPoint;

            // Draw the ray with start point and direction
            Gizmos.DrawRay(startPoint, direction);
            
            Gizmos.color = Color.red;
            Vector3 startPoint1 = laserOrigin.position;
            Vector3 direction1 = hitPoint;
            Gizmos.DrawRay(startPoint1, direction1);
        }
    }
}