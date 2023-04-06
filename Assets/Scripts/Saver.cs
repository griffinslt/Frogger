using System;
using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class Saver : MonoBehaviour
{
    public static Saver Instance { get; set; }
    private static GameObject[] _gameObjects;

    private void Start()
    {
        
    }

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    public static void Save()
    {
        _gameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        string json = "{";
        int logCount = 0;
        foreach (var gameObjectFromArray in _gameObjects)
        {
            if (gameObjectFromArray.CompareTag("Log"))
            {
                json += "Log" + logCount + ":" + gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson() + ",";
                logCount++;
            }
        }

        json += "}";
        print(json);
    }
}
