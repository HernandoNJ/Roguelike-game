using UnityEngine;

namespace z_Old.Levels_2D
{
public class RoomTest2 : MonoBehaviour
{
    [SerializeField] private GameObject topDoor;
    [SerializeField] private GameObject bottomDoor;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    [SerializeField] private GameObject topWall;
    [SerializeField] private GameObject bottomWall;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;

    public bool isInitialRoom;
    
    public bool IsLeftBusy;
    public bool IsRightBusy;
    public bool IsTopBusy;
    public bool IsBottomBusy;

    public bool isLeftRoom;
    public bool isRightRoom;
    
    public Vector2Int RoomIndex { get; set; }

    public void DisableWallAndDoor(Vector2Int direction)
    {
        if (direction == Vector2Int.up)
        {
            topWall.SetActive(false);
            topDoor.SetActive(false);
        }

        if (direction == Vector2Int.down)
        {
            bottomWall.SetActive(false);
            bottomDoor.SetActive(false);
        }

        if (direction == Vector2Int.left)
        {
            leftWall.SetActive(false);
            leftDoor.SetActive(false);
        }

        if (direction == Vector2Int.right)
        {
            rightWall.SetActive(false);
            rightDoor.SetActive(false);
        }
    }
}
}