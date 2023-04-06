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
        _gameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;;
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
        foreach (var gameObjectFromArray in _gameObjects)
        {
            if (gameObjectFromArray.CompareTag("Log"))
            {
                var json = gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson();
                print(json);
            }
        }
       
    }
}
