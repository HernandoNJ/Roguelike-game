using UnityEngine;

namespace Levels_2D
{
public abstract class BaseObjectSpawner : ScriptableObject
{
    public GameObject objectToSpawn;
    public Vector3[] spawnPositions;
    public int spawnCount;

    public abstract void SpawnObjects(Transform parent);
}
}