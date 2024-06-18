using System;
using UnityEngine;

public class Diamond : MonoBehaviour, ICollectables
{
    public void Collect()
    {
        Debug.Log("Diamond collected");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
            Destroy(gameObject);
        }
    }
}
