using System;
using UnityEngine;

namespace _20Feb.Scripts
{
public class RoomsEventManager: MonoBehaviour
{
    public static RoomsEventManager Instance;

    public event Action<Room> OnRoomEntered; // Event for room entry
    public event Action<Room> OnRoomExited;  // Event for room exit

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    public void EnterRoom(Room nextRoom)
    {
        OnRoomEntered?.Invoke(nextRoom);
    }

    public void ExitRoom(Room prevRoom)
    {
        OnRoomExited?.Invoke(prevRoom);
    }
}
}