using System;
using UnityEngine;

public class WallSquare : MonoBehaviour, IShootable
{
    public void Shoot()
    {
        Debug.Log("Object shot. name: " + gameObject.name);
    }
}
