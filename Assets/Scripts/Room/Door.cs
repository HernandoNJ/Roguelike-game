using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Room
{
    public class Door : MonoBehaviour
    {
        public enum DoorPlacement{Up,Down,Left,Right}
        public DoorPlacement place;
        public Vector2 roomGridPos;
        public static event Action<Vector2,DoorPlacement> OnDoorOpened; 
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnDoorOpened?.Invoke(roomGridPos,place);
            }
        }
    }
}