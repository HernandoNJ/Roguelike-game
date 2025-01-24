using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Room
{
    public class Door : MonoBehaviour
    {
        public enum DoorPlacement
        {
            Up,
            Down,
            Left,
            Right
        }

        public DoorPlacement place;
        public Vector2 roomGridPos;
        public bool isExitDoor;
        public Color exitColor;
        public static event Action<Vector2, DoorPlacement> OnDoorOpened;

        private void OnEnable()
        {
            if (isExitDoor)
            {
                GetComponent<SpriteRenderer>().material.color = exitColor;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && isExitDoor)
            {
                OnDoorOpened?.Invoke(roomGridPos, place);
            }
        }
    }
}