using UnityEngine;

namespace Enemy
{
    public class EnemyDamageWall : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("PlayerBullet"))
                Destroy(other.gameObject);
        }
    }
}
