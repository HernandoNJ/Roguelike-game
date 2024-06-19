using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public Player player;
        public float health;
        public float maxHealth;
        public List<GameObject> healthBars;

        private void Start()
        {
            player = GetComponent<Player>();
            health = player.health;
            ClearBars();
            InvokeRepeating(nameof(UpdateHealthBars), 0, 0.2f);
        }
        
        public void AddHealth(int healthAmount)
        {
            health += healthAmount;
            if (health > maxHealth) health = maxHealth;
            UpdateHealthBars();
        }

        public void AddHealthBars(int barsAmount)
        {
            health += 10 * barsAmount;
            if (health > maxHealth) health = maxHealth;
            UpdateHealthBars();
        }
        
        public void Damage(float damageAmount)
        {
            health -= damageAmount;
            if (health < 0) health = 0;
            UpdateHealthBars();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
        
        private void UpdateHealthBars()
        {
            ClearBars();
            if (health <= 0)
                Die();
            
            if (health <= 10)
            {
                healthBars[0].gameObject.SetActive(true);
            }
            else if (health <= 20)
            {
                healthBars[0].gameObject.SetActive(true);
                healthBars[1].gameObject.SetActive(true);
            }
            else if (health <= 30)
            {
                healthBars[0].gameObject.SetActive(true);
                healthBars[1].gameObject.SetActive(true);
                healthBars[2].gameObject.SetActive(true);
            }
            else if (health <= 40)
            {
                healthBars[0].gameObject.SetActive(true);
                healthBars[1].gameObject.SetActive(true);
                healthBars[2].gameObject.SetActive(true);
                healthBars[3].gameObject.SetActive(true);
            }
            else if (health <= 50)
            {
                healthBars[0].gameObject.SetActive(true);
                healthBars[1].gameObject.SetActive(true);
                healthBars[2].gameObject.SetActive(true);
                healthBars[3].gameObject.SetActive(true);
                healthBars[4].gameObject.SetActive(true);
            }
            else if (health <= 60)
            {
                healthBars[0].gameObject.SetActive(true);
                healthBars[1].gameObject.SetActive(true);
                healthBars[2].gameObject.SetActive(true);
                healthBars[3].gameObject.SetActive(true);
                healthBars[4].gameObject.SetActive(true);
                healthBars[5].gameObject.SetActive(true);
            }
        }

        private void ClearBars()
        {
            foreach (var healthBar in healthBars)
                healthBar.SetActive(false);
        }
    }
}