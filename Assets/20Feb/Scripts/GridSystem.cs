using UnityEngine;

namespace _20Feb.Scripts
{
public class GridSystem: MonoBehaviour
{
    [SerializeField] private GameObject[] roomPrefabs; // Room1, Room2, Room3 prefabs
    [SerializeField] private Vector2Int gridSize; // 5x5 grid
    [SerializeField] private Vector2Int roomSize; // Size of each room

    private Room[,] roomsGrid; // 2D array to store Room instances

    private void Start()
    {
        roomsGrid = new Room[gridSize.x, gridSize.y];
        GenerateGrid();
    }
    
    public Vector2Int GetGridSize() => roomSize;
    
    public Room GetRoom(int x, int y) => roomsGrid[x, y];

    public void GenerateGrid()
    {
        for (var x = 0; x < gridSize.x; x++)
        {
            for (var y = 0; y < gridSize.y; y++)
            {
                var position = new Vector3(roomSize.x, 0, roomSize.y);
                var roomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Length)];
                var roomInstance = Instantiate(roomPrefab, position, Quaternion.identity, transform);

                // Store the Room instance in the grid
                roomsGrid[x, y] = roomInstance.GetComponent<Room>();
            }
        }
    }
}
}