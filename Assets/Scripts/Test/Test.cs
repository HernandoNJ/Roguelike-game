using Managers;
using UnityEngine;

namespace Test
{
    public class Test : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            // Fetch the current room grid position from the GameManager
            var currentRoomPosition = GameManager.Instance.GetCurrentRoomPosition();

            // Call GenerateNextRooms with the current room grid position
            GameManager.Instance.GenerateNextRooms(currentRoomPosition);
        }
    }
}