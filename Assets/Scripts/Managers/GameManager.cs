using UI;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIController uiController;
        [SerializeField] private float playerHealth;
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        public void SetPlayerHealth(float health)
        {
            playerHealth = health;
            uiController.UpdateHealthUi(health);
        }

        public float GetPlayerHealth() => playerHealth;
    }
}