using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private float logSpawnDelay = 3f;
    public Transform[] spawnPoints;
    public GameObject log;

     

    
    
    // Update is called once per frame
    void Update()
    {
        if (logSpawnDelay <= 0)
        {
            SpawnLog();
            logSpawnDelay = 3f;
            
        }
        else
        {
            logSpawnDelay -= Time.deltaTime;
        }
    }

    private void SpawnLog()
    {
        Transform startingPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(log, startingPoint.position, startingPoint.rotation);
        print("log spawned");
    }
}
