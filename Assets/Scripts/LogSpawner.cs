using System;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private float countDownTimer = 3f;
    public GameObject log;

    // Update is called once per frame
    void Update()
    {
        if (countDownTimer <= 0)
        {
            SpawnLog();
            countDownTimer = 3f;
            
        }
        else
        {
            countDownTimer -= Time.deltaTime;
        }
    }

    private void SpawnLog()
    {
        Instantiate(log);
        print("log spawned");
    }
}
