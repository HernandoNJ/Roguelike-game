using UnityEngine;

namespace z_Old.Items
{
    [CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/Items")]
    public class Items : ScriptableObject
    {
        public GameObject healthPowerup;
        public GameObject speedPowerup;
        public GameObject fireRatePowerup;
    }
}

