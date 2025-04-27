using UnityEngine;

namespace Room
{
public class DoorTrigger: MonoBehaviour
{
    private Vector2Int direction;

    public void Setup(Vector2Int dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.OnPlayerExitRoom(direction);
        }
    }
}
}