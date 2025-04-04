using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mar23
{
public class ItemsSystem: MonoBehaviour
{
    public Item item;
    public GridSystem gridSystem;
    public List<Item> items;

    private void InstantiateItem(Vector2Int cellPosition)
    {
        //if (!IsCellAvailable(cellPosition)) return;

        var newItem = Instantiate(item, new Vector3(cellPosition.x, cellPosition.y, 0), Quaternion.identity);
        newItem.GetComponent<Item>().SetItemScale();
        items.Add(newItem);

        SetBusyCell(cellPosition);
    }

    public void InstantiateItemsInGrid()
    {
        InstantiateItem(new Vector2Int(2, 3));
        InstantiateItem(new Vector2Int(4, 5));
        InstantiateItem(new Vector2Int(6, 7));
    }

    private bool IsCellAvailable(Vector2Int cellPosition) => gridSystem.GetIsCellAvailable(cellPosition);
    private void SetBusyCell(Vector2Int positionArg) => gridSystem.SetCellAsBusy(positionArg);
}
}