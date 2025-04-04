using UnityEngine;

namespace Mar23
{
public class Item: MonoBehaviour
{
    public Vector2 itemSize;

    public void SetItemScale()
    {
        itemSize = GameGlobalValues.Instance.GetRoomSize();
        transform.localScale = new Vector3(itemSize.x, itemSize.y, 1);
    }
}
}