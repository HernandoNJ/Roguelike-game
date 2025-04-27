using UnityEngine;

namespace z_Old.Mar23
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
            RL_GameManager.Instance.OnPlayerExitRoom(direction);
        }
    }
}
}