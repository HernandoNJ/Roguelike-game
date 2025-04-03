using UnityEngine;
using UnityEngine.Serialization;

namespace Mar23
{
public class GridCell: MonoBehaviour
{
    public Vector2Int cellPosition;
    public Vector2Int cellSize;
    public bool isBusy;

    public void SetGridCellScale()
    {
        transform.localScale = new Vector3(cellSize.x, cellSize.y, 1);
    }
}
}