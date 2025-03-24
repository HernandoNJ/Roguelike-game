using UnityEngine;

namespace Feb20.Scripts
{
public class WallsHandler: MonoBehaviour
{
    private GridSystem gridSystem;

    void Start()
    {
        gridSystem = FindObjectOfType<GridSystem>();
        //DisableMiddleWalls();
    }

    public void DisableMiddleWalls()
    {
        var gridSize = gridSystem.GetGridSize();

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Mar23.Room currentRoom = gridSystem.GetRoom(x, y);

                // Check the room to the right
                if (x < gridSize.x - 1)
                {
                    //Room rightRoom = gridSystem.GetRoom(x + 1, y);
                    //DisableSharedWalls(currentRoom, rightRoom, "RightWall", "LeftWall");
                }

                // Check the room above
                if (y < gridSize.x - 1)
                {
                    //Room topRoom = gridSystem.GetRoom(x, y + 1);
                    //DisableSharedWalls(currentRoom, topRoom, "TopWall", "BottomWall");
                }
            }
        }
    }

    private void DisableSharedWalls(Mar23.Room room1, Mar23.Room room2, string middleWall1, string middleWall2)
    {
        // // Disable the shared walls between two rooms
        // GameObject wall1 = room1.GetWalls().Find(wall => wall.name == middleWall1);
        // GameObject wall2 = room2.GetWalls().Find(wall => wall.name == middleWall2);
        //
        // if (wall1 != null) wall1.SetActive(false);
        // if (wall2 != null) wall2.SetActive(false);
    }
}
}