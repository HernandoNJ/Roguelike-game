using UnityEngine;

namespace z_Old.Levels_2D
{
public class EnemySpawner : BaseObjectSpawner
{
    public override void SpawnObjects(Transform parent)
    {
        for (var i = 0; i < spawnCount; i++)
        {
            Instantiate(objectToSpawn, spawnPositions[i], Quaternion.identity, parent);
        }
    }
}
}