using UnityEngine;
using UnityEngine.Serialization;

namespace Levels_2D
{
public class Door : MonoBehaviour
{
    [FormerlySerializedAs("roomA")] public RoomTest roomTestA;
    [FormerlySerializedAs("roomB")] public RoomTest roomTestB;
    public bool isOpen;

    public void ConnectRooms(RoomTest roomTestOne, RoomTest roomTestTwo)
    {
        roomTestA = roomTestOne;
        roomTestB = roomTestTwo;
        isOpen = true; // Doors are initially open
    }

    public void ToggleDoor() => isOpen = !isOpen;
}
}