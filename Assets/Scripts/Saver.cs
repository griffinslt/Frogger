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
        int turtleCount = 0;
        int carCount = 0;
        int homeFrogCount = 0;
        foreach (var gameObjectFromArray in _gameObjects)
        {
            if (gameObjectFromArray.CompareTag("Log"))
            {
                json += "Log" + logCount + ":" + gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson() + ",";
                logCount++;
            } else if (gameObjectFromArray.CompareTag("Frog"))
            {
                json += "Frog:" + gameObjectFromArray.GetComponent<FrogMovement>().ToJson() + ",";
            }
            else if (gameObjectFromArray.CompareTag("Turtle"))
            {
                json += "Turtle" + turtleCount + ":" + gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson() + ",";
                turtleCount++;
            } else if (gameObjectFromArray.CompareTag("Car"))
            {
                json += "Car" + carCount + ":" + gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson() + ",";
                carCount++;
            } else if (gameObjectFromArray.CompareTag("HomeFrog"))
            {
                json += "HomeFrog" + homeFrogCount + ":" + gameObjectFromArray.GetComponent<HomeFrog>().ToJson() + ",";
                homeFrogCount++;
            }
            
            
        }

        json += "}";
        print(json);
    }
}
