using System;
using Managers;
using UnityEngine;

namespace Room
{
public class DoorTrigger: MonoBehaviour
{
    public Vector2Int direction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.OnPlayerExitRoom(direction);
            gameObject.SetActive(false);
        }
    }

    public void Setup(Vector2Int dir)
    {
        direction = dir;
    }
}
}