using UnityEngine;

namespace Levels_2D
{
public class Door : MonoBehaviour
{
    public Room roomA;
    public Room roomB;
    public bool isOpen;

    public void ConnectRooms(Room roomOne, Room roomTwo)
    {
        roomA = roomOne;
        roomB = roomTwo;
        isOpen = true; // Doors are initially open
    }

    public void ToggleDoor() => isOpen = !isOpen;
}
}