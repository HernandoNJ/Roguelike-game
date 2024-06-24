using TMPro;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject laserIcon;
        [SerializeField] private TextMeshProUGUI healthValueText;

        public void EnableLaserIcon(bool isEnabled) => laserIcon.SetActive(isEnabled);
        public void UpdateHealthUi(float health)
        {
            var myHealth = health.ToString("F2");
            healthValueText.text = myHealth;
        }
    }
}
