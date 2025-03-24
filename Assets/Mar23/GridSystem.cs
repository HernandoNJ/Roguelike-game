using System.Collections.Generic;
using UnityEngine;

namespace Mar23
{
public class GridSystem: MonoBehaviour
{
    public Vector2Int gridSize;
    public Vector2Int itemSize;
    public GameObject itemPrefab;
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
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Instantiate(itemPrefab, new Vector3(i * itemSize.x, j * itemSize.y, 0), Quaternion.identity);
            }
        }
    }
}
}