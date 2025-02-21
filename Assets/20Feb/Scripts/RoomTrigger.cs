using Unity.VisualScripting;
using UnityEngine;

namespace _20Feb.Scripts
{
public class RoomTrigger: MonoBehaviour
{
    [SerializeField] private Room currentRoom;
    [SerializeField] private Room nextRoom;
    [SerializeField] private Room prevRoom;
    [SerializeField] private int roomIndex; // Index of this room
    [SerializeField] private WallsHandler wallsHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var newRoom = other.GetComponent<Room>();
            if (newRoom != null)
            {
                RoomsEventManager.Instance.EnterRoom(nextRoom);
                // Notify the WallManager to disable non-current room walls
                //wallsHandler.DisableMiddleWalls();
            }
            else Debug.LogWarning("RoomCenterPoint not found in the room prefab!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RoomsEventManager.Instance.ExitRoom(nextRoom);
        }
    }
}
}