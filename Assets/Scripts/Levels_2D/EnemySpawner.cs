using UnityEngine;

namespace Levels_2D
{
public class EnemySpawner : BaseObjectSpawner
{
    public override void SpawnObjects(Transform parent)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(objectToSpawn, spawnPositions[i], Quaternion.identity, parent);
        }
    }
}
}