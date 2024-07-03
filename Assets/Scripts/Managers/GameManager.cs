using Player;
using UI;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIController uiController;
        [SerializeField] private Player.Player player;
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerMovement playerMovement;
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        private void Start()
        {
            uiController.EnableLaserIcon(false);
            playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.AddHealth(player.GetPlayerHealth());
            playerMovement = player.GetComponent<PlayerMovement>();
        }

        public void UpdatePlayerHealthUi(float newHealth)
        {
            uiController.UpdateHealthUi(newHealth);
        }

        public Vector3 GetPlayerPosition => player.GetPlayerPosition;
    }
}