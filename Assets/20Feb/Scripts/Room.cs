using System.Collections.Generic;
using UnityEngine;

namespace _20Feb.Scripts
{
public class Room: MonoBehaviour
{
    [SerializeField] private Transform roomCenter;
    
    [SerializeField] private List<GameObject> walls; // assigned in the inspector
    [SerializeField] private List<GameObject> doors; // assigned in the inspector
    
    public Vector3 GetRoomCenter() => roomCenter.position;
    public List<GameObject> GetWalls() => walls;
    public List<GameObject> GetDoors() => doors;
}
}