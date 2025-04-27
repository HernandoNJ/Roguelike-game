using UnityEngine;
using z_Old.Mar23;

namespace Grid
{
public class GridCell: MonoBehaviour
{
    public Vector2Int cellPosition;
    public Vector2 cellSize;
    public bool isBusy;

    public void SetGridCellScale()
    {
        cellSize = GameGlobalValues.Instance.GetRoomSize();
        transform.localScale = new Vector3(cellSize.x, cellSize.y, 1);
    }
}
}