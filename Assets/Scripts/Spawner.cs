using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected float delay;
    protected float _spawnDelay;
    

    protected void Awake()
    {
        _spawnDelay = delay;
    }

    protected void Update()
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

    protected abstract void SpawnGameObject();

}
