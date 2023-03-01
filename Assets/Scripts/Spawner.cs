using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float delay;
    private float _spawnDelay;
    public Transform[] spawnPoints;
    [SerializeField] private GameObject movingGameObject;


    private void Awake()
    {
        _spawnDelay = delay;
    }

    private void Update()
    {
        if (_spawnDelay <= 0)
        {
            SpawnGameObject();
            _spawnDelay = delay ;
        }
        else
        {
            _spawnDelay -= Time.deltaTime;
        }
    }

    private void SpawnGameObject()
    {
        Transform startingPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(movingGameObject, startingPoint.position, startingPoint.rotation);
        print("item spawned");
    }
}
