using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSingleEnemy : SpawnBehaviour
{
    public override void SpawnEnemies()
    {
        GameObject toSpawn = monsters[Random.Range(0, monsters.Count)];
        Vector3 pos = GetPointAroundPlayer();
        GameObject spawnCircle = CreateSpawnCircle(toSpawn, pos);
    }
}
