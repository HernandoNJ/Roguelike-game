using System.Collections.Generic;
using UnityEngine;

namespace z_Old.Mar23
{
public class RoomSystem: MonoBehaviour
{
    public Room roomPrefab;
    public GridSystem gridSystem;
    public List<Room> rooms = new();

    public Room CreateRoom(Vector2Int position)
    {
        if (!gridSystem.GetIsCellAvailable(position)) return null;

        Room newRoom = Instantiate(roomPrefab);
        newRoom.Setup(position);
        rooms.Add(newRoom);

        gridSystem.SetCellAsBusy(position);
        return newRoom;
    }
}
}