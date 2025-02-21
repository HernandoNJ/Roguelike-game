using UnityEngine;

namespace Room
{
    public class RoomManager : MonoBehaviour
    {
        public GameObject roomPrefab;
        public GameObject roomCenterPosPrefab;
        public Transform roomsParent;
        public Transform roomCenterPosParent;
        public int gridX;
        public int gridY;
        public float roomOffsetX;
        public float roomOffsetY;

        private void Start()
        {
            // Set initial values if not set in the inspector
            //Init();
            GenerateRooms();
        }

        private void Init()
        {
            gridX = 5;
            gridY = 5;
            roomOffsetX = 17.75f;
            roomOffsetY = 10f;
        }

        private void GenerateRooms()
        {
            //GenerateRoomsByGrid();
            
        }

        private void GenerateRoomsByGrid()
        {
            var currentXPos = 0f;
            var currentYPos = 0f;

            for (var x = 0; x < gridX; x++)
            {
                for (var y = 0; y < gridY; y++)
                {
                    var newPos = new Vector3(currentXPos, currentYPos, 0f);
                    // Instantiate a room prefab
                    var room = Instantiate(roomPrefab, newPos, Quaternion.identity);
                    room.transform.SetParent(roomsParent);
                    
                    // Optionally, set additional properties for the room
                    room.name = $"Room_{x},{y}";
                    room.GetComponent<RoomController>().gridPosition = new Vector2(x, y);
                    
                    var roomPos = Instantiate(roomCenterPosPrefab, newPos, Quaternion.identity);
                    roomPos.transform.SetParent(roomCenterPosParent);
                    roomPos.name = $"RoomPos_{x},{y}";

                    // Update the Y position for the next room
                    currentYPos += roomOffsetY; 
                }

                // Reset the Y position and increment X position for the next column
                currentYPos = 0f;
                currentXPos += roomOffsetX;
            }

            Debug.Log("Room grid generation complete.");
        }
    }
}