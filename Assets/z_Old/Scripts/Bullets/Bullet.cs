using UnityEngine;

namespace z_Old.Bullets
{
    public class Bullet : MonoBehaviour
    {
        public float speed;
        public float size;
        public float damage;
        public float lifetime;
        public Rigidbody2D rb;

        private void Start()
        {
            Destroy(gameObject, lifetime);
        }
    }
}
