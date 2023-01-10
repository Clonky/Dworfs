using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCluster : SpawnBehaviour
{
    public int maxHPPerCluster;
    public float clusterRadius;
    public override void SpawnEnemies()
    {
        Vector3 positionOfCluster = GetPointAroundPlayer();
        SpawnClusterOfCircles(positionOfCluster);

    }

    void SpawnClusterOfCircles(Vector2 posOfCenter)
    {
        List<GameObject> monsterList = PopulateMonsterList();
        foreach (GameObject imonster in monsterList)
        {
            Vector2 randomPos = GetRandomPointAroundCenter(posOfCenter);
            CreateSpawnCircle(imonster, randomPos);
        }


    }

    List<GameObject> PopulateMonsterList()
    {
        List <GameObject> monsterList = new List<GameObject>();
        GameObject firstMonster = monsters[Random.Range(0, monsters.Count)];
        monsterList.Add(firstMonster);
        while (GetTotalHealthOfList(monsterList) < maxHPPerCluster)
        {
            GameObject newMonster = monsters[Random.Range(0, monsters.Count)];
            monsterList.Add(newMonster);
        }
        return monsterList;
    }

    int GetTotalHealthOfList(List<GameObject> monsterList)
    {
        int counter = 0;
        foreach (GameObject monster in monsterList)
        {
            counter += monster.GetComponent<Stats>().Health;
        }
        return counter;
    }

    Vector3 GetRandomPointAroundCenter(Vector2 center)
    {
        Vector2 pos = center + Random.insideUnitCircle * clusterRadius;
        return pos;
    }
}
