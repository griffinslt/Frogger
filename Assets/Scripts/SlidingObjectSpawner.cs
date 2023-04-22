using UnityEngine;
using Random = UnityEngine.Random;

public class SlidingObjectSpawner : Spawner
{
    [SerializeField] private GameObject gameObjectToSpawn;
    // [SerializeField] private float delay;
    // private float _spawnDelay;
    public Transform[] spawnPoints;
    // [SerializeField] private GameObject movingGameObject;


    // private void Awake()
    // {
    //     _spawnDelay = delay;
    // }

    // private void Update()
    // {
    //     if (_spawnDelay <= 0)
    //     {
    //         SpawnGameObject();
    //         _spawnDelay = delay ;
    //     }
    //     else
    //     {
    //         _spawnDelay -= Time.deltaTime;
    //     }
    // }

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
