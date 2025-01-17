using System;
using UnityEngine;

public class LaserTest : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public bool laserActive;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (laserActive)
        {
            lineRenderer.SetPosition(0, transform.position);
            if (Physics.Raycast(transform.position, Vector3.left, out var hit))
            {
                if (hit.collider)
                    lineRenderer.SetPosition(1, hit.point);
            }
        }
    }
}