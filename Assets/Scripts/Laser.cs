using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float lifetime;

    private void Start()
    {
        Debug.Log("Laser created");
        Destroy(gameObject, lifetime);
    }
}