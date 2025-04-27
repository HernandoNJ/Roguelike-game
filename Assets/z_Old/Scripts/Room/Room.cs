using UnityEngine;

namespace z_Old.Room
{
public class Room: MonoBehaviour
{
    public GameObject topWall, bottomWall, leftWall, rightWall;
    public GameObject topDoor, bottomDoor, leftDoor, rightDoor;
    public bool nextTopFull, nextBottomFull, nextLeftFull, nextRightFull;
}
}