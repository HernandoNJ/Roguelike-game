using Player;
using UnityEngine;

public class DangerItem : MonoBehaviour
{
    [SerializeField] private float stayDamage;
    [SerializeField] private float timeRatio;
    [SerializeField] private float nextDamageTime;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var playerHealth = other.GetComponent<PlayerHealth>();
            
            // Check if conditions are met to apply damage
            if (playerHealth == null || !(Time.time >= nextDamageTime)) return;
            
            // Apply damage & update timer
            playerHealth.Damage(stayDamage);
            nextDamageTime = Time.time + 1f / timeRatio;
        }
    }
}
