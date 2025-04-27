using System.Collections.Generic;
using UnityEngine;

namespace z_Old.Mar23
{
public class GridSystem: MonoBehaviour
{
    [Tooltip("Grid dimensions (use odd numbers for centered start cell)")]
    public Vector2Int gridDimensions;

    public GridCell cell;
    public GridCell startCell;
    public List<GridCell> availableCells;
    public List<GridCell> busyCells;
    private readonly Dictionary<Vector2Int, GridCell> gridCellsDictionary = new();

    public void GenerateGridCells()
    {
        var tempRoomSize = GameGlobalValues.Instance.GetRoomSize();

        for (int i = 0; i < gridDimensions.x; i++)
        {
            for (int j = 0; j < gridDimensions.y; j++)
            {
                var tempPosition = new Vector2Int(i, j);

                var newCell = Instantiate(cell,
                    new Vector3(i * tempRoomSize.x, j * tempRoomSize.y, 0),
                    Quaternion.identity,
                    transform);

                newCell.cellPosition = tempPosition;
                newCell.cellSize = GameGlobalValues.Instance.GetRoomSize();
                newCell.SetGridCellScale();
                newCell.isBusy = false;

                availableCells.Add(newCell);
                gridCellsDictionary.Add(tempPosition, newCell);
            }
        }
    }

    public void SetStartGridCell()
    {
        var centralPosition = new Vector2Int((gridDimensions.x / 2), (gridDimensions.y / 2));
        GameGlobalValues.Instance.SetInitialGridPosition(centralPosition);
        foreach (var cellObj in availableCells)
        {
            var tempCell = cellObj.GetComponent<GridCell>();
            if (tempCell.cellPosition != centralPosition) continue;

            // startCell is used only as testing reference
            startCell = tempCell;
            tempCell.GetComponent<Renderer>().material.color = Color.green;
            break;
        }
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
        if (!gridCellsDictionary.TryGetValue(positionArg, out var gridCell))
        {
            Debug.LogError($"Grid cell is not in dictionary {positionArg}");
            return false;
        }
    
        return !gridCell.isBusy;
    }
}
}