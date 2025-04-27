using TMPro;
using UnityEngine;

namespace z_Old.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject laserIcon;
        [SerializeField] private GameObject laserIconTransp;
        [SerializeField] private TextMeshProUGUI healthValueText;

        public void EnableLaserIcon(bool enableIcon)
        {
            laserIcon.SetActive(enableIcon);
            laserIconTransp.SetActive(!enableIcon);
        }

        public void UpdateHealthUi(float health)
        {
            var myHealth = health.ToString("F2");
            healthValueText.text = myHealth;
        }
    }
}
