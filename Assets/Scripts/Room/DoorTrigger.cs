using Managers;
using UnityEngine;

namespace Room
{
public class DoorTrigger: MonoBehaviour
{
    private Vector2Int direction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) GameManager.Instance.OnPlayerExitRoom(direction);
    }

    public void Setup(Vector2Int dir)
    {
        direction = dir;
    }
}
}