using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawnable[] prefabs;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float respawnRate = 10;

    [SerializeField] private float initialSpawnDelay;
    
    [SerializeField] private int totalNumberToSpawn;
    
    [SerializeField] private int numberToSpawnEachTime = 1;

    private float spawnTimer;
    private int totalNumberSpawned;
    private void OnEnable()
    {
        spawnTimer = respawnRate - initialSpawnDelay;
    }
    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (ShouldSpawn())
            Spawn();
    }

    private bool ShouldSpawn()
    {
        return spawnTimer >= respawnRate && totalNumberSpawned < totalNumberToSpawn;
    }

    private void Spawn()
    {
        spawnTimer = 0;
        var avaiableSpawnPoints = spawnPoints.ToList();
        for (int i = 0; i < numberToSpawnEachTime; i++)
        {
            if (totalNumberSpawned >= totalNumberToSpawn) break;
            var prefab = ChooseRandomPrefab();
            if (prefab != null)
            {
                var spawnPoint = ChooseRandomSpawnPoint(avaiableSpawnPoints);
                if (avaiableSpawnPoints.Contains(spawnPoint))
                    avaiableSpawnPoints.Remove(spawnPoint);
                var spawnable = prefab.Get<Spawnable>(spawnPoint.position, spawnPoint.rotation);
                totalNumberSpawned++;
            }
        }
        
    }

    private Transform ChooseRandomSpawnPoint(List<Transform> avaiableSpawnPoints)
    {
        
        return spawnPoints.Length == 0 ? null : avaiableSpawnPoints[Random.Range(0, avaiableSpawnPoints.Count)];
    }

    private Spawnable ChooseRandomPrefab()
    {
        return prefabs.Length == 0 ? null : prefabs[Random.Range(0, prefabs.Length)];
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (var spawnPoint in spawnPoints)
        {
            Gizmos.DrawSphere(spawnPoint.position,0.5f);
        }
    }
    #endif
}
