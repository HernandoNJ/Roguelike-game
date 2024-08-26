using System.Collections.Generic;
using UnityEngine;

namespace Levels_2D
{
public class RoomController : MonoBehaviour
{
    public ObjectsSpawnerReference objectsSpawnerReference;
    public GameObject doorPrefab;
    public GameObject roomPrefab;
    public GameObject baseRoomPrefab;
    public GameObject combinedRoom2Prefab;
    public GameObject combinedRoom3Prefab;

    private bool isLevelComplete = false;
    private int enemiesRemaining = 0;
    
    public List<Room> rooms;
    public List<Level> levels;

    private void Start()
    {
        // Instantiate the room and doors
        InstantiateRoom();
        InstantiateDoors();

        // Spawn objects using the provided spawner reference
        objectsSpawnerReference.spawner.SpawnObjects(transform);

        // Update the enemies remaining count based on spawned enemies
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Update()
    {
        if (isLevelComplete)
        {
            // Trigger level completion logic (e.g., load next level)
        }
    }

    private void InstantiateRoom()
    {
        Instantiate(roomPrefab, transform.position, Quaternion.identity);
    }
    
    public void GenerateLevel(int levelIndex)
    {
        // Determine the number of rooms and their types based on the level index
        int numRooms = GetNumRoomsForLevel(levelIndex);
        List<RoomType> roomTypes = GetRoomTypesForLevel(levelIndex);

        // Create the rooms
        for (int i = 0; i < numRooms; i++)
        {
            var roomObj = SelectRoomPrefab(roomTypes[i]);
            var roomGameObject = Instantiate(roomObj, transform.position, Quaternion.identity);
            var newRoom = roomGameObject.GetComponent<Room>();
            rooms.Add(newRoom);
        }

        // Connect the rooms randomly
        for (int i = 0; i < rooms.Count - 1; i++)
        {
            Room currentRoom = rooms[i];
            Room nextRoom = rooms[Random.Range(i + 1, rooms.Count)];
            currentRoom.ConnectToRoom(currentRoom, nextRoom);
        }

        // Place the special door
        Room lastRoom = rooms[rooms.Count - 1];
        lastRoom.PlaceSpecialDoor();

        // Set the level's rooms and special door
        levels[levelIndex].rooms = rooms;
        levels[levelIndex].specialDoor = lastRoom.specialDoor;
    }

    private GameObject SelectRoomPrefab(RoomType roomType)
    {
        switch (roomType)
        {
            case RoomType.BaseRoom:
                return baseRoomPrefab;
            case RoomType.CombinedRoom2:
                return combinedRoom2Prefab;
            case RoomType.CombinedRoom3:
                return combinedRoom3Prefab;
            default:
                Debug.Log("Room prefab not found");
                return null; // Handle unexpected room types
        }
    }
    
    // Helper functions to determine the number and types of rooms for a given level
    private int GetNumRoomsForLevel(int levelIndex)
    {
        // Implement your logic here to determine the number of rooms based on the level index
        return levelIndex + 2; // Example: 2 rooms for level 0, 3 rooms for level 1, etc.
    }

    private List<RoomType> GetRoomTypesForLevel(int levelIndex)
    {
        // Implement your logic here to determine the types of rooms for the level
        List<RoomType> roomTypes = new List<RoomType>();
        roomTypes.Add(RoomType.BaseRoom); // Example: Always include at least one BaseRoom
        // Add other room types based on the level index
        return roomTypes;
    }

    private void InstantiateDoors()
    {
        // Instantiate doors based on room configuration
    }
}
public enum RoomType
{
    BaseRoom,
    CombinedRoom2,
    CombinedRoom3
}
}