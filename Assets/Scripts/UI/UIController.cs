using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject laserIcon;

        public void EnableLaserIcon(bool isEnabled) => laserIcon.SetActive(isEnabled);
    }
}
