using UnityEngine;

namespace z_Old.Feb20.Scripts
{
public class CameraBackgroundHandler: MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Color backgroundColor = Color.gray;
    [SerializeField] private GameObject cameraBackgroundObj;

    private void Start()
    {
        CreateBackgroundSprite();
    }

    public void CreateBackgroundSprite()
    {
        // Scale the background to cover the entire camera viewport
        var cameraHeight = mainCamera.orthographicSize * 2;
        var cameraWidth = cameraHeight * mainCamera.aspect;
        cameraBackgroundObj.transform.localScale = new Vector3(cameraWidth, cameraHeight, 1);

        // Position the background behind the room
        cameraBackgroundObj.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 10); // Z > 0 to ensure it's behind the room

        // Set the background color
        cameraBackgroundObj.GetComponent<SpriteRenderer>().color = backgroundColor;
    }
}
}