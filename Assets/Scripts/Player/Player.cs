using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float health;
        [SerializeField] private float playerSpeed;
        [SerializeField] private float fireRatio;
        [SerializeField] private Vector2 playerFacingVector;

        public float GetPlayerHealth() => health;
        public float GetPlayerFireRatio() => fireRatio;
        public float GetPlayerSpeed() => playerSpeed;
        public Vector3 GetPlayerPosition => transform.position;

    }
}