using System.Collections.Generic;
using UnityEngine;

namespace Mar23
{
public class GridSystem: MonoBehaviour
{ 
    [Tooltip("Grid dimensions (use odd numbers for centered start cell)")]
    public Vector2Int gridSize;
    
    public Vector2Int startCell;
    public Vector2Int itemSize;
    public GameObject itemPrefab;
    public List<GameObject> items;
    public List<Vector2Int> initialCells;
    public List<Vector2Int> busyCells;
    
    public bool IsGridCellFull(Vector2Int position) => busyCells.Contains(position);
    public void AddGridCell(Vector2Int position) => busyCells.Add(position);
    public void RemoveGridCell(Vector2Int position) => busyCells.Remove(position);

    private void Start()
    {
        itemSize = itemPrefab.GetComponent<Item>().itemSize;
        GenerateGrid();
        SetStartGridCell();
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                var cellPosition = new Vector2Int(i, j);
                var newItem = Instantiate(itemPrefab, new Vector3(i * itemSize.x, j * itemSize.y, 0), Quaternion.identity);
                newItem.GetComponent<Item>().gridCellPosition = cellPosition;
                items.Add(newItem);
                initialCells.Add(cellPosition);
            }
        }
    }

    private void SetStartGridCell()
    {
        startCell = new Vector2Int((gridSize.x/2), (gridSize.y/2));
        foreach (var item in items)
        {
            var tempItem = item.GetComponent<Item>();
            if (tempItem.gridCellPosition != startCell) continue;
            
            item.GetComponent<Renderer>().material.color = Color.green;
            break;
        }
    }
}
}