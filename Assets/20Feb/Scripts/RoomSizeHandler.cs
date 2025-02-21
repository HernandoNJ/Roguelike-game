using UnityEngine;

namespace _20Feb.Scripts
{
public class RoomSizeHandler: MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject baseRoomPrefab;
    [SerializeField] private float hudHeight = 100f; // Space for HUD in pixels

    private void Start()
    {
        AdjustRoomPrefabSize();
    }

    public void AdjustRoomPrefabSize()
    {
        // Get the camera's viewport size in world units
        var cameraHeight = mainCamera.orthographicSize * 2;
        var cameraWidth = cameraHeight * mainCamera.aspect;

        // Adjust for HUD space
        var roomHeight = cameraHeight - (hudHeight / Screen.height * cameraHeight);

        // Scale the room prefab to match the camera's width and adjusted height
        var newScale = new Vector3(cameraWidth, roomHeight, 1);
        baseRoomPrefab.transform.localScale = newScale;

        // Position the room prefab to align with the camera
        baseRoomPrefab.transform.position = new Vector3(
            mainCamera.transform.position.x,
            mainCamera.transform.position.y - (hudHeight / Screen.height * cameraHeight / 2), 0);
    }
}
}