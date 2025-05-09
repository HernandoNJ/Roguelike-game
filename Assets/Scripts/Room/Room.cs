using Misc;
using UnityEngine;

namespace Room
{
public class Room: MonoBehaviour
{
    public Vector2Int gridPosition;
    public DoorTrigger upDoor;
    public DoorTrigger downDoor;
    public DoorTrigger leftDoor;
    public DoorTrigger rightDoor;

    private void Start()
    {
        SetupDoors();
    }

    public void Setup(Vector2Int position)
    {
        gridPosition = position;
        var roomSize = GameGlobalValues.Instance.GetRoomSize();
        transform.position = new Vector3(position.x * roomSize.x, position.y * roomSize.y, 0);
    }

    private void SetupDoors()
    {
        if (upDoor != null) upDoor.Setup(Vector2Int.up);
        if (downDoor != null) downDoor.Setup(Vector2Int.down);
        if (leftDoor != null) leftDoor.Setup(Vector2Int.left);
        if (rightDoor != null) rightDoor.Setup(Vector2Int.right);
    }
}
}