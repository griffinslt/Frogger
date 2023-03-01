using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 3f;
    public Transform[] spawnPoints;
    [SerializeField] private GameObject movingGameObject;

    private void Update()
    {
        if (spawnDelay <= 0)
        {
            SpawnGameObject();
            spawnDelay = 3f;
        }
        else
        {
            spawnDelay -= Time.deltaTime;
        }
    }

    private void SpawnGameObject()
    {
        Transform startingPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(movingGameObject, startingPoint.position, startingPoint.rotation);
        print("item spawned");
    }
}
