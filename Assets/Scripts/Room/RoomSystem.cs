using System.Collections.Generic;
using Grid;
using UnityEngine;

namespace Room
{
    // RoomSystem handles the creation and management of rooms in the grid system.
    public class RoomSystem : MonoBehaviour
    {
        public Room roomPrefab;           // Prefab for creating rooms
        public GridSystem gridSystem;     // Reference to the grid system
        public List<Room> rooms = new();  // List of all created rooms

        // Creates a room at a given grid position if the cells are available.
        public Room CreateRoom(Vector2Int position)
        {
            // Check if the grid cell is available for placing a room
            if (!gridSystem.GetIsCellAvailable(position))
            {
                Debug.LogWarning($"Room cannot be created. Cell at {position} is unavailable.");
                return null;
            }

            // Instantiate a new room using the prefab
            var newRoom = Instantiate(roomPrefab);
            newRoom.Setup(position); // Setup room-specific parameters
            rooms.Add(newRoom);      // Add the room to the list of rooms

            // Mark the grid cell as occupied
            gridSystem.SetCellAsBusy(position);
            return newRoom;
        }
    }
}