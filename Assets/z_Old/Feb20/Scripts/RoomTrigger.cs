using UnityEngine;

namespace z_Old.Feb20.Scripts
{
public class RoomTrigger: MonoBehaviour
{
    [SerializeField] private Mar23.Room currentRoom;
    [SerializeField] private Mar23.Room nextRoom;
    [SerializeField] private Mar23.Room prevRoom;
    [SerializeField] private int roomIndex; // Index of this room
    [SerializeField] private WallsHandler wallsHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var newRoom = other.GetComponent<Mar23.Room>();
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