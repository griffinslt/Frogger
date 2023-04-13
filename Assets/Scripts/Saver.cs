
using System.IO;
using UnityEngine;


public class Saver : MonoBehaviour
{
    public static Saver Instance { get; set; }
    private static GameObject[] _gameObjects;
    public static string FOLDER; 

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
        
        FOLDER = Application.dataPath + "/SaveFiles/"; 
    }

    public static void Save()
    {
        if (!Directory.Exists(FOLDER))
        {
            Directory.CreateDirectory(FOLDER);
        }
        string dateTime = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        string json = GetJson();
        File.WriteAllText(FOLDER + dateTime + ".json", json);
    }

    private static string GetJson()
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
                json += "\"Log" + logCount + "\":" + gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson() + ",";
                logCount++;
            } else if (gameObjectFromArray.CompareTag("Frog"))
            {
                json += "\"Frog\":" + gameObjectFromArray.GetComponent<FrogMovement>().ToJson() + ",";
            }
            else if (gameObjectFromArray.CompareTag("Turtle"))
            {
                json += "\"Turtle" + turtleCount + "\":" + gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson() + ",";
                turtleCount++;
            } else if (gameObjectFromArray.CompareTag("Car"))
            {
                json += "\"Car" + carCount + "\":" + gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson() + ",";
                carCount++;
            } else if (gameObjectFromArray.CompareTag("HomeFrog"))
            {
                json += "\"HomeFrog" + homeFrogCount + "\":" + gameObjectFromArray.GetComponent<HomeFrog>().ToJson() + ",";
                homeFrogCount++;
            }
        }

        json = json.Remove(json.Length - 1);
        json += "}";
        return json;
    }
}
