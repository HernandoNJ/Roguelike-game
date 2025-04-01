using UnityEngine;

namespace Mar23
{
public class Item: MonoBehaviour
{
    public Vector2Int itemSize;
    public Vector2Int gridCellPosition;

    private void Start()
    {
        transform.localScale = new Vector3(itemSize.x, itemSize.y, 1);
    }
}
}