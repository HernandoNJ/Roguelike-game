using System;
using UnityEngine;

namespace z_Old.Feb20.Scripts
{
public class RoomsEventManager: MonoBehaviour
{
    public static RoomsEventManager Instance;

    public event Action<Mar23.Room> OnRoomEntered; // Event for room entry
    public event Action<Mar23.Room> OnRoomExited;  // Event for room exit

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    public void EnterRoom(Mar23.Room nextRoom)
    {
        OnRoomEntered?.Invoke(nextRoom);
    }

    public void ExitRoom(Mar23.Room prevRoom)
    {
        OnRoomExited?.Invoke(prevRoom);
    }
}
}