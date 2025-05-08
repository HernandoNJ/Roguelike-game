using System.Collections.Generic;
using Misc;
using UnityEngine;

namespace Grid
{
public class GridSystem: MonoBehaviour
{
    public Vector2Int gridDimensions = new(5, 5);

    public GridCell cell;
    public Transform startPosition;
    public List<GridCell> availableCells;
    public List<GridCell> busyCells;
    public Dictionary<Vector2Int, GridCell> gridCellsDictionary = new();

    public void GenerateGridCells()
    {
        var tempRoomSize = GameGlobalValues.Instance.GetRoomSize();

        for (var i = 0; i < gridDimensions.y; i++)
        for (var j = 0; j < gridDimensions.x; j++)
        {
            var tempPosition = new Vector2Int(i, j);

            var newCell = Instantiate(cell,
                new Vector3(i * tempRoomSize.x, j * tempRoomSize.y, 0),
                Quaternion.identity,
                transform);

            newCell.cellPosition = tempPosition;
            newCell.cellSize = tempRoomSize;
            newCell.SetGridCellScale();
            newCell.isBusy = false;

            availableCells.Add(newCell);
            gridCellsDictionary.Add(tempPosition, newCell);
        }
    }

    public void SetStartGridCell()
    {
        var startPos2D = new Vector2Int(
            Mathf.RoundToInt(startPosition.position.x),
            Mathf.RoundToInt(startPosition.position.y)
        );

        GameGlobalValues.Instance.SetInitialGridPosition(startPos2D);
    }

    public void SetCellAsBusy(Vector2Int positionArg)
    {
        if (!gridCellsDictionary.TryGetValue(positionArg, out var gridCell)) return;

        gridCell.isBusy = true;
        availableCells.Remove(gridCell);
        busyCells.Add(gridCell);
    }

    public bool GetIsCellAvailable(Vector2Int positionArg)
    {
        if (gridCellsDictionary.TryGetValue(positionArg, out _)) return true;

        Debug.LogError($"Grid cell is not in dictionary {positionArg}");
        return false;
    }
}
}