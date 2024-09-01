using System;
using System.Collections.Generic;
using UnityEngine;

namespace Room
{
public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private int maxRooms = 15;
    [SerializeField] private int minRooms = 10;

    // Room size
    private int roomWidth = 20;
    private int roomHeight = 12;

    // Grid size
    private int gridSizeX = 10;
    private int gridSizeY = 10;

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
        var initialRoomIndex = new Vector2Int(gridSizeX/2, gridSizeY/2);
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
        roomQueue.Enqueue(roomIndex);
        
        var x = roomIndex.x;
        var y = roomIndex.y;

        roomGrid[x, y] = 1;
        roomCount++;
        
        var positionFromGridIndex = GetPositionFromGridIndex(roomIndex);
        var newRoom = Instantiate(roomPrefab, positionFromGridIndex, Quaternion.identity);
        
        newRoom.GetComponent<Room>().RoomIndex = roomIndex;
        newRoom.name = "Room-" + roomCount;
        roomObjects.Add(newRoom);
    
        return true;
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