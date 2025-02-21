using UnityEngine;

namespace _20Feb.Scripts
{
public class CameraController: MonoBehaviour
{
    private void OnEnable()
    {
        // Subscribe to the OnRoomEntered event
        RoomsEventManager.Instance.OnRoomEntered += MoveCameraToRoomCenter;
    }

    private void OnDisable()
    {
        // Unsubscribe from the OnRoomEntered event
        if (RoomsEventManager.Instance != null)
        {
            RoomsEventManager.Instance.OnRoomEntered -= MoveCameraToRoomCenter;
        }
    }

    // Method to move the camera to the room center
    private void MoveCameraToRoomCenter(Room room)
    {
        var roomCenter = room.GetRoomCenter();
        
        // Move the camera to the room center (keep the same Y position)
        transform.position = new Vector3(roomCenter.x, transform.position.y, roomCenter.z);
    }
}
}