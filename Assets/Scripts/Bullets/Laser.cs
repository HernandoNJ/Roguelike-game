using UnityEngine;

namespace Bullets
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private float lifetime;

        private void Start()
        {
            Debug.Log("Laser created");
            Destroy(gameObject, lifetime);
        }
    }
}