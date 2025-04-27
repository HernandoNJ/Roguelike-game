using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace z_Old.Levels_2D
{
public class RoomTest : MonoBehaviour
{
    [SerializeField] private GameObject doorPrefab;
    [SerializeField] private GameObject specialDoorPrefab;

    public RoomType type;
    public Vector3 position;
    [FormerlySerializedAs("connectedDoors")] public List<Door> connectedDoorsList;
    public Door specialDoor;
    
    public int maxDoors;
    public bool hasEnemy;
    
    public void ConnectToRoom(RoomTest room1, RoomTest room2)
    {
        // Create a door between the two rooms
        var doorGameObject = Instantiate(doorPrefab, transform.position, Quaternion.identity);
        var door = doorGameObject.GetComponent<Door>();
        door.ConnectRooms(room1, room2);
        connectedDoorsList.Add(door);
        room1.connectedDoorsList.Add(door);
    }

    public void PlaceSpecialDoor()
    {
        // Instantiate a special door and connect it to the room
        var specialDoorGameObject = Instantiate(specialDoorPrefab, transform.position, Quaternion.identity);
        specialDoor = specialDoorGameObject.GetComponent<Door>();
        connectedDoorsList.Add(specialDoor);
    }
}
}