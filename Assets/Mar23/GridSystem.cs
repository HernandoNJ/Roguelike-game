using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mar23
{
public class GridSystem: MonoBehaviour
{
    public Vector2Int containerSize;
    public Vector2Int startGrid;
    public Vector2Int itemSize;
    public GameObject itemPrefab;
    public List<Vector2Int> availableGridList;
    public List<Vector2Int> busyGridList;
    
    public bool IsGridBusy(Vector2Int position) => busyGridList.Contains(position);
    public void AddGrid(Vector2Int position) => busyGridList.Add(position);
    public void RemoveGrid(Vector2Int position) => busyGridList.Remove(position);

    private void Start()
    {
        itemSize = itemPrefab.GetComponent<Item>().itemSize;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int i = 0; i < containerSize.x; i++)
        {
            for (int j = 0; j < containerSize.y; j++)
            {
                Instantiate(itemPrefab, new Vector3(i * itemSize.x, j * itemSize.y, 0), Quaternion.identity);
                availableGridList.Add(new Vector2Int(i,j));
            }
        }
    }

    public void SetStartGrid()
    {
        var x = startGrid.x;
        var y = startGrid.y;
        startGrid = new Vector2Int(x/2, y/2);
        
    }
}
}