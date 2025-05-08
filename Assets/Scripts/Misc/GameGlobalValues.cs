using UnityEngine;

namespace Misc
{
public class GameGlobalValues: MonoBehaviour
{
    public Vector2 roomSize;
    public Vector2Int initialGridPosition;
    public static GameGlobalValues Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public Vector2 GetRoomSize()
    {
        return roomSize;
    }

    public void SetInitialGridPosition(Vector2Int gridPositionArg)
    {
        initialGridPosition = gridPositionArg;
    }

    public Vector2Int GetInitialGridPosition()
    {
        return initialGridPosition;
    }
}
}