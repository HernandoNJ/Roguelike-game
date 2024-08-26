using Player;
using UnityEngine;

namespace Powerups
{
    public class SpeedPowerup : MonoBehaviour, ICollectables
    {
        [SerializeField] private float speedToAdd;
        public void Collect()
        {
            Debug.Log("Speed powerup collected");
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var playerMove = other.GetComponent<PlayerMovement2>();
                playerMove?.IncreaseSpeed(speedToAdd);
                
                Collect();
                Destroy(gameObject);
            }
        }
    }
}
