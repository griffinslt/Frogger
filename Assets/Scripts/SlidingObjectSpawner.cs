using UnityEngine;
using Random = UnityEngine.Random;

public class SlidingObjectSpawner : Spawner
{
    [SerializeField] private GameObject gameObjectToSpawn;
    public Transform[] spawnPoints;
    
    protected override void SpawnGameObject()
    {
        Transform startingPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if (gameObject.CompareTag("Turtle"))
        {
            print(startingPoint.position.x);
        }
        var newSlidingObject = Instantiate(gameObjectToSpawn, startingPoint.position, startingPoint.rotation);
        newSlidingObject.name = "clone";
    }
}
