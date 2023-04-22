using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : Spawner
{
    [SerializeField] private GameObject[] powerUps;

    protected override void SpawnGameObject()
    {
        var y = Random.Range(0, 12);
        var x = Random.Range(-6, 6);
        var position = new Vector2(x, y);
        var powerUpElement = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[powerUpElement], position, new Quaternion(0,0,0,0));
    }
}
