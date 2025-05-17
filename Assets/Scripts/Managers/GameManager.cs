using System.Collections.Generic;
using Grid;
using Misc;
using Room;
using UnityEngine;

namespace Managers
{
public class GameManager: MonoBehaviour
{
    public GridSystem gridSystem;
    public RoomSystem roomSystem;
    public Transform player;
    public Room.Room currentRoom;
    public Vector2Int currentPlayerGridPos;
    public float randRoomsAmount;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        gridSystem.GenerateGridCells();
        gridSystem.SetStartGridCell();

        // Create initial room at start position
        var startPos = GameGlobalValues.Instance.GetInitialGridPosition();
        currentRoom = roomSystem.CreateRoom(startPos);
        player.position = currentRoom.transform.position;
        currentPlayerGridPos = currentRoom.gridPosition;
        //GenerateSurroundingRooms(startPos);
    }
    private void GenerateSurroundingRooms(Vector2Int centerPosition)
    {
        // Vector2Int[] directions =
        //     { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        //
        // List<Vector2Int> availablePositions = new();
        //
        // foreach (var dir in directions)
        // {
        //     var newPos = centerPosition + dir;
        //
        //     if (gridSystem.GetIsCellAvailable(newPos)) availablePositions.Add(newPos);
        // }
        //
        // randRoomsAmount = Mathf.Min(3, availablePositions.Count);
        //
        // for (var i = 0; i < randRoomsAmount; i++)
        // {
        //     var randIndex = Random.Range(0, availablePositions.Count);
        //     var selectedPos = availablePositions[randIndex];
        //     roomSystem.CreateRoom(selectedPos);
        //     availablePositions.RemoveAt(randIndex);
        // }
    }
    public void OnPlayerExitRoom(Vector2Int direction)
    {
        Debug.Log("Player Exited room");
        var nextPosition = currentRoom.gridPosition + direction;
        Debug.Log("current room grid position: " + currentRoom.gridPosition);
        Debug.Log("next position: " + nextPosition);
        
        foreach (var room in roomSystem.rooms)
        {
            Debug.Log("Checking for room");
            if (room.gridPosition == nextPosition)
            {
                roomSystem.CreateRoom(nextPosition);
                break;
            }
        }
        
        // // Calculate the next room's position in grid space
        // var nextPosition = currentRoom.gridPosition + direction;
        // Debug.Log("current room grid position: " + currentRoom.gridPosition);;
        //
        // // Find or create the next room
        // var nextRoom = roomSystem.rooms.Find(r => r.gridPosition == nextPosition);
        // if (!nextRoom)
        // {
        //     // Create the next room if it doesn't exist
        //     nextRoom = roomSystem.CreateRoom(nextPosition);
        //     GenerateSurroundingRooms(nextPosition);
        //     Debug.Log("Generate surrounding rooms in current room grid position: " + currentRoom.gridPosition);;
        // }
        //
        // if (nextRoom)
        // {
        //     // Set nextRoom as the current active room
        //     currentRoom = nextRoom;
        //     currentPlayerGridPos = nextRoom.gridPosition;
        //
        //     // Align the player's position with the corresponding door in the next room
        //     var roomSize = GameGlobalValues.Instance.GetRoomSize();
        //     var offset = new Vector3(direction.x * roomSize.x / 2, direction.y * roomSize.y / 2, 0);
        //     Debug.Log("Player position before next room: " +  player.position);
        //     player.position = nextRoom.transform.position + offset;
        //     Debug.Log("Player position after next room: " +  player.position);
        // }
        
    }
    public void GenerateNextRooms(Vector2Int centerPos) => GenerateSurroundingRooms(centerPos);
    public Vector2Int GetCurrentRoomPosition()
    {
        return currentRoom.gridPosition;
    }
}
}