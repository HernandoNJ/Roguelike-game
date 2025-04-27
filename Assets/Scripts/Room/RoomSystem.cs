using System.Collections.Generic;
using Grid;
using UnityEngine;

namespace Room
{
public class RoomSystem: MonoBehaviour
{
    public Room roomPrefab;
    public GridSystem gridSystem;
    public List<Room> rooms = new();

    
    
    public Room CreateRoom(Vector2Int position)
    {
        if (gridSystem.GetIsCellAvailable(position) == false)
        {
            Debug.Log("Grid system cell available is false");
            return null;
        }

        var newRoom = Instantiate(roomPrefab);
        newRoom.Setup(position);
        rooms.Add(newRoom);

        gridSystem.SetCellAsBusy(position);
        return newRoom;
    }
}
}