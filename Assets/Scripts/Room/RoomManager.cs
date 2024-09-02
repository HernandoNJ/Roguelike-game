using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Room
{
public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private int maxRooms = 15;
    [SerializeField] private int minRooms = 10;

    // Grid size
    [SerializeField] private int gridSizeX = 10;
    [SerializeField] private int gridSizeY = 10;
    
    // Room size
    private int roomWidth = 20;
    private int roomHeight = 12;

    // List of rooms
    private List<GameObject> roomObjects = new List<GameObject>();

    private Queue<Vector2Int> roomQueue = new Queue<Vector2Int>();

    // New grid to spawn rooms
    private int[,] roomGrid;

    private int roomCount;
    private bool isRoomsGenerationComplete = false;

    private void Start()
    {
        // Set spawning grid value
        roomGrid = new int[gridSizeX, gridSizeY];
        //roomQueue = new Queue<Vector2Int>();
        var initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
        StartRoomGenerationFromIndex(initialRoomIndex);
    }

    private void Update()
    {
        if (roomQueue.Count > 0 && roomCount < maxRooms && !isRoomsGenerationComplete)
        {
            var roomIndex = roomQueue.Dequeue();
            var gridX = roomIndex.x;
            var gridY = roomIndex.y;

            // Try to generate rooms in all 4 directions
            TryGenerateRoom(new Vector2Int(gridX - 1, gridY));
            TryGenerateRoom(new Vector2Int(gridX + 1, gridY));
            TryGenerateRoom(new Vector2Int(gridX, gridY - 1));
            TryGenerateRoom(new Vector2Int(gridX, gridY + 1));
        }
        else if (roomCount < minRooms)
        {
            Debug.Log("Room count less that min. Trying again");
            RegenerateRooms();
        }
        else if (!isRoomsGenerationComplete)
        {
            isRoomsGenerationComplete = true;
            Debug.Log("*** Rooms generation completed. Rooms: " + roomCount);
        }
    }

    private void StartRoomGenerationFromIndex(Vector2Int roomIndex)
    {
        roomQueue.Enqueue(roomIndex);
        var x = roomIndex.x;
        var y = roomIndex.y;
        roomGrid[x, y] = 1;
        roomCount++;
        var positionFromGridIndex = GetPositionFromGridIndex(roomIndex);
        var initialRoom = Instantiate(roomPrefab, positionFromGridIndex, Quaternion.identity);
        initialRoom.name = "Room-" + roomCount;
        initialRoom.GetComponent<Room>().RoomIndex = roomIndex;
        roomObjects.Add(initialRoom);
    }

    private bool TryGenerateRoom(Vector2Int roomIndex)
    {
        var x = roomIndex.x;
        var y = roomIndex.y;

        if (roomCount >= maxRooms ||
            (Random.value < 0.5f && roomIndex != Vector2Int.zero))
            return false;

        // Snake like rooms generation, optional
        if (CountAdjacentRooms(roomIndex) > 1) // Check if count exceeds 1
            return false;

        roomQueue.Enqueue(roomIndex);
        roomGrid[x, y] = 1;
        roomCount++;

        var positionFromGridIndex = GetPositionFromGridIndex(roomIndex);
        var newRoom = Instantiate(roomPrefab, positionFromGridIndex, Quaternion.identity);

        newRoom.GetComponent<Room>().RoomIndex = roomIndex;
        newRoom.name = "Room-" + roomCount;
        roomObjects.Add(newRoom);

        OpenDoors(newRoom, x, y);

        return true;
    }
    
    // In case rooms generation fails,
    // Clear all rooms and try again
    private void RegenerateRooms()
    {
        ResetRoomsGeneration();
        
        var initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
        StartRoomGenerationFromIndex(initialRoomIndex);
    }

    private void ResetRoomsGeneration()
    {
        roomObjects.ForEach(Destroy);
        roomObjects.Clear();
        roomGrid = new int[gridSizeX, gridSizeY];
        roomQueue.Clear();
        roomCount = 0;
        isRoomsGenerationComplete = false;
    }

    private int CountAdjacentRooms(Vector2Int roomIndex)
    {
        var x = roomIndex.x;
        var y = roomIndex.y;
        var count = 0;

        count = GetNeighboursCount(x, y, count);

        return count;
    }

    private int GetNeighboursCount(int x, int y, int count)
    {
        var leftNeighbourPlaced = x > 0 && roomGrid[x - 1, y] != 0;
        var rightNeighbourPlaced = x < gridSizeX - 1 && roomGrid[x + 1, y] != 0;
        var bottomNeighbourPlaced = y > 0 && roomGrid[x, y - 1] != 0;
        var topNeighbourPlaced = y < gridSizeY - 1 && roomGrid[x, y + 1] != 0;
        
        if (leftNeighbourPlaced ||
            rightNeighbourPlaced ||
            bottomNeighbourPlaced ||
            topNeighbourPlaced) 
            count++; 
        
        return count;
    }

    // Return the position of the room based on the gridIndex
    private Vector3 GetPositionFromGridIndex(Vector2Int gridIndex)
    {
        var gridX = gridIndex.x;
        var gridY = gridIndex.y;
        var newGridVector =
            new Vector3(roomWidth * (gridX - gridSizeX / 2),
                roomHeight * (gridY - gridSizeY / 2));
        return newGridVector;
    }

    private void OpenDoors(GameObject room, int x, int y)
    {
        var newRoomScript = room.GetComponent<Room>();

        // Neighbours
        var leftRoomScript = GetRoomScriptAt(new Vector2Int(x - 1, y));
        var rightRoomScript = GetRoomScriptAt(new Vector2Int(x + 1, y));
        var topRoomScript = GetRoomScriptAt(new Vector2Int(x , y + 1));
        var bottomRoomScript = GetRoomScriptAt(new Vector2Int(x , y-1));
        
        var leftNeighbourPlaced = x > 0 && roomGrid[x - 1, y] != 0;
        var rightNeighbourPlaced = x < gridSizeX - 1 && roomGrid[x + 1, y] != 0;
        var bottomNeighbourPlaced = y > 0 && roomGrid[x, y - 1] != 0;
        var topNeighbourPlaced = y < gridSizeY - 1 && roomGrid[x, y + 1] != 0;
        
        // Determine open doors based on the direction
        if (leftNeighbourPlaced)
        {
            newRoomScript.OpenDoor(Vector2Int.left);
            leftRoomScript.OpenDoor(Vector2Int.right);
        }
        if (rightNeighbourPlaced)
        {
            newRoomScript.OpenDoor(Vector2Int.right);
            rightRoomScript.OpenDoor(Vector2Int.left);
        }
        if (bottomNeighbourPlaced)
        {
            newRoomScript.OpenDoor(Vector2Int.down);
            bottomRoomScript.OpenDoor(Vector2Int.up);
        }
        if (topNeighbourPlaced)
        {
            newRoomScript.OpenDoor(Vector2Int.up);
            topRoomScript.OpenDoor(Vector2Int.down);
        }
        
    }

    private Room GetRoomScriptAt(Vector2Int index)
    {
        var roomObject = roomObjects.Find(
            room => room.GetComponent<Room>().RoomIndex == index);
        if (roomObject != null)
            return roomObject.GetComponent<Room>();
        
        return null;
    }

    // Draw the grid in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 1, 0.05f);
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                var position = GetPositionFromGridIndex(new Vector2Int(x, y));
                Gizmos.DrawWireCube(position, new Vector3(roomWidth, roomHeight, 1));
                // For Vector2Int v1 = new Vector2Int(0,0);:new Vector2Int(-100, -60);
                // For Vector2Int v1 = new Vector2Int(0,1);: new Vector2Int(-100, -48)
                // For Vector2Int v2 = new Vector2Int(0,2);: new Vector2Int(-100, -36)
                // For Vector2Int v3 = new Vector2Int(0,3);: new Vector2Int(-100, -24)
            }
        }
    }
}
}