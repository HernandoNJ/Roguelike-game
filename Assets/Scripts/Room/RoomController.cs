using System.Collections.Generic;
using UnityEngine;

namespace Room
{
    public class RoomController : MonoBehaviour
    {
        public Vector2 gridPosition;
        public List<GameObject> doors;
        public GameObject topWall, bottomWall, leftWall, rightWall;

        private Dictionary<Door.DoorPlacement, GameObject> wallMap;

        private void OnEnable()
        {
            Door.OnDoorOpened += HandleDoorOpened;
            MapDoors();
        }

        private void OnDisable()
        {
            Door.OnDoorOpened -= HandleDoorOpened;
        }

        private void HandleDoorOpened(Vector2 roomGridPos, Door.DoorPlacement doorPos)
        {
            // Get a wall gameobject if the doorPos value is in the dictionary
            if (wallMap.TryGetValue(doorPos, out GameObject wall))
            {
                wall.SetActive(false);
            }
        }

        public void InitializeRoom(Vector2 position)
        {
            gridPosition = position;

            // Set grid position for each door
            foreach (var door in doors)
            {
                var doorComponent = door.GetComponent<Door>();
                if (doorComponent != null)
                {
                    doorComponent.roomGridPos = position;
                }
            }
        }

        private void MapDoors()
        {
            // Map doors to walls based on their placement
            wallMap = new Dictionary<Door.DoorPlacement, GameObject>
            {
                { Door.DoorPlacement.Up, topWall },
                { Door.DoorPlacement.Down, bottomWall },
                { Door.DoorPlacement.Left, leftWall },
                { Door.DoorPlacement.Right, rightWall }
            };
        }
    }
}