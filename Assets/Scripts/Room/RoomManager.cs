using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private int roomWidth = 20;
    [SerializeField] private int roomHeight = 12;

    // List of instantiated rooms
    private List<GameObject> roomObjects = new List<GameObject>();

    // Manage rooms generation process
    private Queue<Vector2Int> roomQueue = new Queue<Vector2Int>();

    // New grid to spawn rooms
    private int[,] roomGrid;

    // Rooms created
    private int roomCount;

    private bool isInitialRoomPlaced;

    public Vector2Int initialRoomIndex;
    public Vector2Int currentRoomIndex;
    public Room curreRoomScript;
    public Room nextRoomScript;
    
    private void Start()
    {
        // Initialize the grid and start the room generation process
        roomGrid = new int[gridSizeX, gridSizeY];
        maxRooms = Random.Range(minRooms, maxRooms + 1);

        // Generate rooms starting from the first room
        // Rooms generation starting in the center
        // InitialRoomIndex = (5,5)
        // var initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
        // GenerateRoom(initialRoomIndex);

        initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
        currentRoomIndex = initialRoomIndex;

        for (int i = 0; i < maxRooms; i++) GenerateRoom(currentRoomIndex);
        //GenerateRooms();
    }

    private void GenerateRoom(Vector2Int roomIndex)
    {
        // If the first room
        // Enqueue (5,5) - roomGrid[5,5] = 1;
        // Used to check if a room is created at [5,5]
        roomQueue.Enqueue(roomIndex);
        roomGrid[roomIndex.x, roomIndex.y] = 1;
        roomCount++;

        // InitialRoomIndex = (5,5), result = (0,0,0)
        var position = GetPositionFromGridIndex(roomIndex);

        // Instantiate the room at position (50,30)
        var roomObj = Instantiate(roomPrefab, position, Quaternion.identity);
        roomObj.name = "Room-" + roomCount;

        // Set the room index (V2int)
        // Add the room to the roomobjects list
        var roomScript = roomObj.GetComponent<Room>();
        roomScript.RoomIndex = roomIndex;
        roomObjects.Add(roomObj);

        if (roomCount == 1)
        {
            curreRoomScript = roomScript;
            curreRoomScript.isInitialRoom = true;
        }
        else nextRoomScript = roomScript;

        if (roomScript.isInitialRoom == false)
        {
            if (!curreRoomScript.IsLeftBusy)
            {
                curreRoomScript.IsLeftBusy = true;
                curreRoomScript.DisableWallAndDoor(Vector2Int.left);
                nextRoomScript.DisableWallAndDoor(Vector2Int.right);
                currentRoomIndex = new Vector2Int(initialRoomIndex.x - 1, initialRoomIndex.y);
                var newPosition = GetPositionFromGridIndex(currentRoomIndex);
                roomObj.transform.position = newPosition;
            }
            else if (!curreRoomScript.IsTopBusy)
            {
                curreRoomScript.IsTopBusy = true;
                curreRoomScript.DisableWallAndDoor(Vector2Int.up);
                nextRoomScript.DisableWallAndDoor(Vector2Int.down);
                currentRoomIndex = new Vector2Int(initialRoomIndex.x, initialRoomIndex.y + 1);
                var newPosition = GetPositionFromGridIndex(currentRoomIndex);
                roomObj.transform.position = newPosition;
            }
            else if (!curreRoomScript.IsRightBusy)
            {
                curreRoomScript.IsRightBusy = true;
                curreRoomScript.DisableWallAndDoor(Vector2Int.right);
                nextRoomScript.DisableWallAndDoor(Vector2Int.left);
                currentRoomIndex = new Vector2Int(initialRoomIndex.x + 1, initialRoomIndex.y);
                var newPosition = GetPositionFromGridIndex(currentRoomIndex);
                roomObj.transform.position = newPosition;
            }
            else if (!curreRoomScript.IsBottomBusy)
            {
                curreRoomScript.IsBottomBusy = true;
                curreRoomScript.DisableWallAndDoor(Vector2Int.down);
                nextRoomScript.DisableWallAndDoor(Vector2Int.up);
                currentRoomIndex = new Vector2Int(initialRoomIndex.x, initialRoomIndex.y - 1);
                var newPosition = GetPositionFromGridIndex(currentRoomIndex);
                roomObj.transform.position = newPosition;
            }
        }
    }

    // private void GenerateRooms1(Vector2Int initialRoomIndex)
    // {
    //     // Place 4 rooms adjacent to initial Room
    //     // InitialRoomIndex = (5,5)
    // }
    //
    // private void GenerateRooms()
    // {
    //     while (roomCount < maxRooms && roomQueue.Count > 0)
    //     {
    //         var currentRoomIndex = roomQueue.Dequeue(); // Get the current room's index
    //         TryGenerateRoom(currentRoomIndex);
    //     }
    // }

    // private void TryGenerateRoom(Vector2Int currentRoomIndex)
    // {
    //     List<Vector2Int> directions = new List<Vector2Int>
    //     {
    //         Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
    //     };
    //
    //     Shuffle(directions);
    //
    //     foreach (var direction in directions)
    //     {
    //         Vector2Int newRoomIndex = currentRoomIndex + direction;
    //
    //         if (IsWithinBounds(newRoomIndex) && roomGrid[newRoomIndex.x, newRoomIndex.y] == 0)
    //         {
    //             roomGrid[newRoomIndex.x, newRoomIndex.y] = 1;
    //             roomCount++;
    //
    //             var position = GetPositionFromGridIndex(newRoomIndex);
    //             var newRoom = Instantiate(roomPrefab, position, Quaternion.identity);
    //             newRoom.name = "Room-" + roomCount;
    //
    //             var roomScript = newRoom.GetComponent<Room>();
    //             roomScript.RoomIndex = newRoomIndex;
    //             roomObjects.Add(newRoom);
    //
    //             roomQueue.Enqueue(newRoomIndex);
    //
    //             // Disable shared walls and open doors between current and new rooms
    //             UpdateWallsAndDoors(roomScript, currentRoomIndex, direction);
    //
    //             // Stop after placing one room
    //             break;
    //         }
    //     }
    // }

    // private void UpdateWallsAndDoors(Room newRoom, Vector2Int currentRoomIndex, Vector2Int direction)
    // {
    //     var currentRoom = roomObjects.Find(room => room.GetComponent<Room>().RoomIndex == currentRoomIndex);
    //
    //     if (currentRoom != null)
    //     {
    //         // Open door and disable wall between the current and new rooms
    //         var currentRoomScript = currentRoom.GetComponent<Room>();
    //         currentRoomScript.DisableDoor(direction); // Open door in the current room's direction
    //         currentRoomScript.DisableWall(direction); // Disable the wall in the current room
    //
    //         // Open door and disable wall in the new room (in the opposite direction)
    //         newRoom.DisableDoor(-direction);
    //         newRoom.DisableWall(-direction);
    //     }
    //
    //     // Ensure outer walls are enabled
    //     UpdateOuterWalls(newRoom);
    // }


    // private void UpdateOuterWalls(Room room)
    // {
    //     Vector2Int index = room.RoomIndex;
    //
    //     // Ensure outer walls are enabled where no adjacent room exists
    //     if (index.y == gridSizeY - 1 || roomGrid[index.x, index.y + 1] == 0)
    //         room.EnableWall(Vector2Int.up); // Top row or no room above
    //
    //     if (index.y == 0 || roomGrid[index.x, index.y - 1] == 0)
    //         room.EnableWall(Vector2Int.down); // Bottom row or no room below
    //
    //     if (index.x == 0 || roomGrid[index.x - 1, index.y] == 0)
    //         room.EnableWall(Vector2Int.left); // Leftmost column or no room to the left
    //
    //     if (index.x == gridSizeX - 1 || roomGrid[index.x + 1, index.y] == 0)
    //         room.EnableWall(Vector2Int.right); // Rightmost column or no room to the right
    // }

    private Vector3 GetPositionFromGridIndex(Vector2Int gridIndex)
    {
        // gridIndex = 5,5
        // offsetX = 20 * (5-10/2) = 20*0 = 0
        // offsetY = 12 * (5-10/2) = 0

        // gridIndex = 5,6
        // offsetX = 20 * (5-10/2) = 20*0 = 0
        // offsetY = 12 * (6-10/2) = 12*1 = 12

        // gridIndex = 2,3
        // offsetX = -60
        // offsetY = -24

        var offsetX = roomWidth * (gridIndex.x - gridSizeX / 2);
        var offsetY = roomHeight * (gridIndex.y - gridSizeY / 2);
        return new Vector3(offsetX, offsetY, 0);
    }

    private bool IsWithinBounds(Vector2Int index)
    {
        return index.x >= 0 && index.x < gridSizeX && index.y >= 0 && index.y < gridSizeY;
    }

// Helper function to shuffle directions (Fisher-Yates Shuffle)
    private void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }


    // private void Start()
    // {
    //     // Initialize grid and start generation
    //     // roomGrid = [10,10]
    //     roomGrid = new int[gridSizeX, gridSizeY];
    //     maxRooms = Random.Range(minRooms, maxRooms + 1);
    //
    //     GenerateFirstRoom();
    // }
    //


    // private void UpdateWallsAndDoors(Room room)
    // {
    //     var index = room.RoomIndex;
    //
    //     // Check adjacent rooms to determine if doors/walls should be enabled or disabled
    //     if (index.y == gridSizeY - 1) 
    //         room.DisableWall(Vector2Int.up); // Top row
    //     else if (roomGrid[index.x, index.y + 1] == 1) 
    //         room.OpenDoor(Vector2Int.up);
    //
    //     if (index.y == 0) 
    //         room.DisableWall(Vector2Int.down); // Bottom row
    //     else if (roomGrid[index.x, index.y - 1] == 1) 
    //         room.OpenDoor(Vector2Int.down);
    //
    //     if (index.x == 0) 
    //         room.DisableWall(Vector2Int.left); // Leftmost column
    //     else if (roomGrid[index.x - 1, index.y] == 1) 
    //         room.OpenDoor(Vector2Int.left);
    //
    //     if (index.x == gridSizeX - 1) 
    //         room.DisableWall(Vector2Int.right); // Rightmost column
    //     else if (roomGrid[index.x + 1, index.y] == 1) 
    //         room.OpenDoor(Vector2Int.right);
    // }


    // private void GenerateFirstRoom()
    // {
    //     // Rooms generation starting in the center
    //     // InitialRoomIndex = (5,5)
    //     var initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
    //
    //     // Enqueue (5,5) - roomGrid[5,5] = 1;
    //     // Used to check if a room is created at [5,5]
    //     roomQueue.Enqueue(initialRoomIndex);
    //     roomGrid[initialRoomIndex.x, initialRoomIndex.y] = 1;
    //     roomCount++;
    //
    //     // InitialRoomIndex = (5,5), result = (0,0,0)
    //     var position = GetPositionFromGridIndex(initialRoomIndex);
    //
    //     // Instantiate the room at position (50,30)
    //     var initialRoom = Instantiate(roomPrefab, position, Quaternion.identity);
    //     initialRoom.name = "Room-" + roomCount;
    //
    //     // Set the room index (V2int)
    //     // Add the room to the roomobjects list
    //     var roomScript = initialRoom.GetComponent<Room>();
    //     roomScript.RoomIndex = initialRoomIndex;
    //     roomObjects.Add(initialRoom);
    // }

    // Generates the (0,0,0) position for any item of the grid[,] using the gridIndex


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 1, 0.05f);
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                var position = GetPositionFromGridIndex(new Vector2Int(x, y));
                Gizmos.DrawWireCube(position, new Vector3(roomWidth, roomHeight, 1));
            }
        }
    }
}
}

// public static class ListExtensions
// {
//     // Shuffle extension method to randomize the list
//     public static void Shuffle<T>(this IList<T> list)
//     {
//         var rng = new System.Random();
//         int n = list.Count;
//         while (n > 1)
//         {
//             n--;
//             int k = rng.Next(n + 1);
//             T value = list[k];
//             list[k] = list[n];
//             list[n] = value;
//         }
//     }
// }
// }


// private void Update()
// {
//     if (roomQueue.Count > 0 && roomCount < maxRooms && !isRoomsGenerationComplete)
//     {
//         var roomIndex = roomQueue.Dequeue();
//         GenerateRandomAdjacentRooms(roomIndex);
//     }
//     else if (roomCount < minRooms)
//     {
//         Debug.Log("Room count less than min. Trying again");
//         RegenerateRooms();
//     }
//     else if (!isRoomsGenerationComplete)
//     {
//         isRoomsGenerationComplete = true;
//         Debug.Log("*** Rooms generation completed. Rooms: " + roomCount);
//     }
// }


// // Start generating rooms
// private void StartRoomGenerationFromIndex()
// {
//     // Rooms generation starting in the center
//     // InitialRoomIndex = (5,5)
//     var initialRoomIndex = new Vector2Int(gridSizeX / 2, gridSizeY / 2);
//     
//     // Enqueue (5,5) - roomGrid[5,5] = 1;
//     // Used to check if a room is created at [5,5]
//     roomQueue.Enqueue(initialRoomIndex);
//     roomGrid[initialRoomIndex.x, initialRoomIndex.y] = 1;
//     roomCount++;
//     
//     // InitialRoomIndex = (5,5), result = (0,0,0)
//     var position = GetPositionFromGridIndex(initialRoomIndex);
//
//     // Instantiate the room at position (50,30)
//     var initialRoom = Instantiate(roomPrefab, position, Quaternion.identity);
//     initialRoom.name = "Room-" + roomCount;
//     
//     // Set the room index (V2int)
//     // Add the room to the roomobjects list
//     var roomScript = initialRoom.GetComponent<Room>();
//     roomScript.RoomIndex = initialRoomIndex;
//     roomObjects.Add(initialRoom);
// }

// private void GenerateRandomAdjacentRooms(Vector2Int roomIndex)
// {
//     var directions = new List<Vector2Int> 
//     { 
//         Vector2Int.left, 
//         Vector2Int.right, 
//         Vector2Int.down, 
//         Vector2Int.up 
//     };
//
//     // Shuffle directions to randomize generation
//     directions.Shuffle();
//
//     foreach (var direction in directions)
//     {
//         // 5,5 + -1,0 = -4,5
//         // 5,5 + 1,0 = 6,5
//         // 5,5 + 0,-1 = 5,-4
//         // 5,5 + 0,1 = 5,6
//         var adjacentRoomIndex = roomIndex + direction;
//         GenerateRoom(adjacentRoomIndex);
//     }
// }
//
// private bool GenerateRoom(Vector2Int roomIndex)
// {
//     if (roomCount >= maxRooms ||
//         roomIndex.x < 0 || roomIndex.x >= gridSizeX ||
//         roomIndex.y < 0 || roomIndex.y >= gridSizeY ||
//         roomGrid[roomIndex.x, roomIndex.y] != 0 ||
//         Random.value < 0.5f)
//         return false;
//
//     roomQueue.Enqueue(roomIndex);
//     roomGrid[roomIndex.x, roomIndex.y] = 1;
//     roomCount++;
//     
//     //
//     var position = GetPositionFromGridIndex(roomIndex);
//     var newRoom = Instantiate(roomPrefab, position, Quaternion.identity);
//     newRoom.name = "Room-" + roomCount;
//     var roomScript = newRoom.GetComponent<Room>();
//     roomScript.RoomIndex = roomIndex;
//     roomObjects.Add(newRoom);
//
//     OpenDoorsAndWalls(newRoom, roomIndex);
//
//     return true;
// }
//
// private void RegenerateRooms()
// {
//     ResetRoomsGeneration();
//     StartRoomGenerationFromIndex();
// }
//
// private void ResetRoomsGeneration()
// {
//     foreach (var room in roomObjects)
//         Destroy(room);
//     roomObjects.Clear();
//     roomGrid = new int[gridSizeX, gridSizeY];
//     roomQueue.Clear();
//     roomCount = 0;
//     isRoomsGenerationComplete = false;
// }
//
// private void OpenDoorsAndWalls(GameObject room, Vector2Int roomIndex)
// {
//     var roomScript = room.GetComponent<Room>();
//
//     var leftRoom = GetRoomScriptAtIndex(new Vector2Int(roomIndex.x - 1, roomIndex.y));
//     var rightRoom = GetRoomScriptAtIndex(new Vector2Int(roomIndex.x + 1, roomIndex.y));
//     var topRoom = GetRoomScriptAtIndex(new Vector2Int(roomIndex.x, roomIndex.y + 1));
//     var bottomRoom = GetRoomScriptAtIndex(new Vector2Int(roomIndex.x, roomIndex.y - 1));
//
//     if (leftRoom != null)
//     {
//         roomScript.OpenDoor(Vector2Int.left);
//         roomScript.DisableWall(Vector2Int.left);
//         leftRoom.OpenDoor(Vector2Int.right);
//         leftRoom.DisableWall(Vector2Int.right);
//     }
//     if (rightRoom != null)
//     {
//         roomScript.OpenDoor(Vector2Int.right);
//         roomScript.DisableWall(Vector2Int.right);
//         rightRoom.OpenDoor(Vector2Int.left);
//         rightRoom.DisableWall(Vector2Int.left);
//     }
//     if (bottomRoom != null)
//     {
//         roomScript.OpenDoor(Vector2Int.down);
//         roomScript.DisableWall(Vector2Int.down);
//         bottomRoom.OpenDoor(Vector2Int.up);
//         bottomRoom.DisableWall(Vector2Int.up);
//     }
//     if (topRoom != null)
//     {
//         roomScript.OpenDoor(Vector2Int.up);
//         roomScript.DisableWall(Vector2Int.up);
//         topRoom.OpenDoor(Vector2Int.down);
//         topRoom.DisableWall(Vector2Int.down);
//     }
// }
//
// private Room GetRoomScriptAtIndex(Vector2Int index)
// {
//     var roomObject = roomObjects.Find(room => room.GetComponent<Room>().RoomIndex == index);
//     return roomObject ? roomObject.GetComponent<Room>() : null;
// }