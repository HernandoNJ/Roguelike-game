using System;
using System.Collections.Generic;
using UnityEngine;

namespace Room
{
public class RoomController: MonoBehaviour
{
    public Vector2Int roomSize;
    public Vector2Int currentGridPos;
    public Vector2 offset;
    public GameObject cubeTest;

    private void Start()
    {
        InitRooms();
    }

    private void InitRooms()
    {
        
    }
}
}