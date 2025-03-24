using UnityEngine;

namespace Feb20.Scripts
{
public class GameManager: MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private RoomSizeHandler roomSizeHandler;
    [SerializeField] private CameraBackgroundHandler cameraBackgroundHandler;
    [SerializeField] private CameraResolutionHandler cameraResolutionHandler;
    [SerializeField] private WallsHandler wallsHandler;
    [SerializeField] private RoomsEventManager roomsEventManager;
    [SerializeField] private GridSystem gridSystem;
    
    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Initialize the ResolutionHandler
        if (cameraResolutionHandler != null)
            cameraResolutionHandler.Init();

        // Generate the grid
        gridSystem.GenerateGrid();
        //wallsHandler.DisableMiddleWalls();

        if (roomsEventManager != null)
        {
            // Example: Set up event listeners
            roomsEventManager.OnRoomEntered += HandleRoomEntered;
        }
    }

    private void HandleRoomEntered(Mar23.Room room)
    {
        // Handle room entry logic (e.g., move camera, update walls)
        Debug.Log($"Player entered room at {room.name}");
    }
}
}