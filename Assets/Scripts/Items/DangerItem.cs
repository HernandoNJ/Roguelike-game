using Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class DangerItem : MonoBehaviour
{
    [SerializeField] private float stayDamage;
    [SerializeField] private float timeRatio;
    [SerializeField] private float nextDamageTime;
    [SerializeField] private bool isHurting;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isHurting = Random.Range(0, 50) > 30;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isHurting) return;
        
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
