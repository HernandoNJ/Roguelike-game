using System.Collections.Generic;
using UnityEngine;
using z_Old.Managers;

namespace z_Old.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        //public Player player;
        public float health;
        public float maxHealth;
        public List<GameObject> healthBars;
        
        public void AddHealth(float healthAmount)
        {
            health += healthAmount;
            if (health > maxHealth) health = maxHealth;
            UpdateHealth();
        }

        // Called when picking up Health powerups
        public void AddHealthBars(int barsAmount)
        {
            health += 10 * barsAmount;
            if (health > maxHealth) health = maxHealth;
            UpdateHealth();
        }
        
        public void Damage(float damageAmount)
        {
            health -= damageAmount;
            Managers.GameManager.Instance.UpdatePlayerHealthUi(health);
            
            if (health < 0) health = 0;
            UpdateHealth();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
        
        private void UpdateHealth()
        {
            ClearBars();
            Managers.GameManager.Instance.UpdatePlayerHealthUi(health);
            
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