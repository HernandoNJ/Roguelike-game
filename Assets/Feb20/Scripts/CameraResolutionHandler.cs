using UnityEngine;

namespace Feb20.Scripts
{
public class CameraResolutionHandler: MonoBehaviour
{
    [SerializeField] private RoomSizeHandler roomSizeHandler;
    [SerializeField] private CameraBackgroundHandler cameraBackgroundHandler;

    public void Init()
    {
        // Adjust room size and create background once at the start of the game
        roomSizeHandler.AdjustRoomPrefabSize();
        cameraBackgroundHandler.CreateBackgroundSprite();
    }
}
}