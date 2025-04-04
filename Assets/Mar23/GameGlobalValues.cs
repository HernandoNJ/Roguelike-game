using UnityEngine;

namespace Mar23
{
public class GameGlobalValues: MonoBehaviour
{
    public static GameGlobalValues Instance { get; private set; }
    public Vector2 roomSize;
    public Vector2Int initialGridPosition;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    
    public Vector2 GetRoomSize() => roomSize;
    public void SetInitialGridPosition(Vector2Int gridPositionArg) => initialGridPosition = gridPositionArg;
    public Vector2Int GetInitialGridPosition() => initialGridPosition;
}
}