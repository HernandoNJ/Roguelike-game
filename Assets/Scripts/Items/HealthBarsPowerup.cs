using Player;
using UnityEngine;

namespace Items
{
    public class HealthBarsPowerup : MonoBehaviour, ICollectables
    {
        public int barsToAdd;
        
        public void Collect()
        {
            Debug.Log("Health bar powerup collected");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var playerHealth = other.GetComponent<PlayerHealth>();
                var n = Random.Range(1,20);
                barsToAdd = n > 10 ? 2 : 1;
                
                playerHealth?.AddHealthBars(barsToAdd);
                Collect();
                Destroy(gameObject);
            }
        }
    }
}
