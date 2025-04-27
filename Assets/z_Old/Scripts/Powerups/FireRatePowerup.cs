using UnityEngine;
using z_Old.Player;

namespace z_Old.Powerups
{
    public class FireRatePowerup : MonoBehaviour, ICollectables
    {
        [SerializeField] private float fireRateToAdd;
        public void Collect()
        {
            Debug.Log("Fire rate powerup collected");
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var playerShooting = other.GetComponent<PlayerShooting>();
                playerShooting?.IncreaseFireRate(fireRateToAdd);
                
                Collect();
                Destroy(gameObject);
            }
        }
    }
}
