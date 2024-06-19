using Player;
using UI;
using UnityEngine;

namespace Items
{
    public class LaserPowerup : MonoBehaviour, ICollectables
    {
        [SerializeField] private float speedToAdd;
        public void Collect()
        {
            Debug.Log("Laser powerup collected");
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var playerShooting = FindObjectOfType<Player.Player>().GetComponent<PlayerShooting>();
                playerShooting?.EnableLaser();
                
                Collect();
                Destroy(gameObject);
            }
        }
    }
}
