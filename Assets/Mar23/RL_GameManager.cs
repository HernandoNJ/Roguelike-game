using UnityEngine;

namespace Mar23
{
public class RL_GameManager:MonoBehaviour
{
    public GridSystem gridSystem;
    public ItemsSystem itemsSystem;
    
    private void Start()
    {
        gridSystem.GenerateGridCells();
        gridSystem.SetStartGridCell();
        itemsSystem.InstantiateItemsInGrid();
    }
}
}