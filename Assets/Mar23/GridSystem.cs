using System.Collections.Generic;
using UnityEngine;

namespace Mar23
{
public class GridSystem: MonoBehaviour
{
    public Vector2Int roomSize;
    
    [Tooltip("Grid dimensions (use odd numbers for centered start cell)")]
    public Vector2Int gridDimensions;

    public GridCell cell;
    public GridCell startCell;

    public Item item;

    public List<GridCell> availableCells;
    public List<GridCell> busyCells;
    public List<GameObject> itemObjects;


    // public bool IsGridCellBusy(Vector2Int position) => busyCells.Contains(position);
    // public void AddBusyCell(Vector2Int position) => busyCells.Add(position);
    // public void RemoveBusyCell(Vector2Int position) => busyCells.Remove(position);

    private void Start()
    {
        GenerateGridCells();
        SetStartGridCell();
    }

    private void GenerateGridCells()
    {
        for (int i = 0; i < gridDimensions.x; i++)
        {
            for (int j = 0; j < gridDimensions.y; j++)
            {
                var tempPosition = new Vector2Int(i, j);
                var newCell = Instantiate(cell, new Vector3(i * roomSize.x, j * roomSize.y, 0), Quaternion.identity);
                newCell.cellPosition = tempPosition;
                newCell.cellSize = roomSize;
                newCell.SetGridCellScale();
                newCell.isBusy = false;
                availableCells.Add(newCell);
            }
        }
    }

    private void SetStartGridCell()
    {
        var centralPosition = new Vector2Int((gridDimensions.x / 2), (gridDimensions.y / 2));
        foreach (var cellObj in availableCells)
        {
            var tempCell = cellObj.GetComponent<GridCell>();
            if (tempCell.cellPosition != centralPosition) continue;
            
            startCell = tempCell; // only for test reference
            tempCell.GetComponent<Renderer>().material.color = Color.green;
            break;
        }
    }

    private void InstantiateItem(Vector2Int cellPosition)
    {
        // var newItem = Instantiate(item, new Vector3(cellPosition.x, cellPosition.y, 0), Quaternion.identity);
        // newItem.GetComponent<Item>().gridCellPosition = cellPosition;
        // ChangeCellState(cellPosition);
        // itemObjects.Add(newItem);


        // var cellPosition = new Vector2Int(i, j);
        // var newItem = Instantiate(item, new Vector3(i * itemSize.x, j * itemSize.y, 0), Quaternion.identity);
        // newItem.gridCellPosition = cellPosition;
        // itemObjects.Add(newItem.gameObject);
        // availableCells.Add(cellPosition);
    }
    // private void SetNewGridCells(Vector2Int cellPosition, int itemsAmount)
    // {
    // }
    //
    // private void ChangeCellState(Vector2Int cellPosition)
    // {
    //     if (busyCells.Contains(cellPosition))
    //     {
    //         availableCells.Add(cellPosition);
    //         busyCells.Remove(cellPosition);
    //     }
    //     else
    //     {
    //         availableCells.Remove(cellPosition);
    //         busyCells.Add(cellPosition);
    //     }
}
}