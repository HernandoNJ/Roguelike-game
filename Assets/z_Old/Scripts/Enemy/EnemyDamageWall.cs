using UnityEngine;

namespace z_Old.Enemy
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
