using System.Collections.Generic;
using Grid;
using Room;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GridSystem gridSystem;
    public RoomSystem roomSystem;
    public Transform player;
    private Room.Room currentRoom;

    private void Awake()
    {
        if (Instance != null && Instance != this)
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
        
        //player.position = currentRoom.transform.position;

        GenerateSurroundingRooms(startPos);
    }
    
    private void GenerateSurroundingRooms(Vector2Int centerPosition)
    {
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        
        List<Vector2Int> availablePositions = new();

        foreach (var dir in directions)
        {
            var newPos = centerPosition + dir;
            
            if (gridSystem.GetIsCellAvailable(newPos))
            {
                availablePositions.Add(newPos);
            }
        }

        int roomsToCreate = Mathf.Min(3, availablePositions.Count);

        for (int i = 0; i < roomsToCreate; i++)
        {
            var randIndex = Random.Range(0, availablePositions.Count);
            var selectedPos = availablePositions[randIndex];
            
            roomSystem.CreateRoom(selectedPos);
            
            availablePositions.RemoveAt(randIndex);
        }
    }

    public void OnPlayerExitRoom(Vector2Int direction)
    {
        var nextPosition = currentRoom.gridPosition + direction;

        var nextRoom = roomSystem.rooms.Find(r => r.gridPosition == nextPosition);
        if (nextRoom == null)
        {
            nextRoom = roomSystem.CreateRoom(nextPosition);
            GenerateSurroundingRooms(nextPosition);
        }

        if (nextRoom != null)
        {
            currentRoom = nextRoom;
            player.position = nextRoom.transform.position;
        }
    }
}