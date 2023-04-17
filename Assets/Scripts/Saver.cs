
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Saver : MonoBehaviour
{
    public static Saver Instance { get; set; }
    private static GameObject[] _gameObjects;
    private static string _folder;
    private static string _sceneName;
    
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
        _sceneName = SceneManager.GetActiveScene().name;
        _folder = Application.dataPath + "/SaveFiles/" +  SceneManager.GetActiveScene().name + "/"; 
        
    }

    public static void Save()
    {
        if (!Directory.Exists(_folder))
        {
            Directory.CreateDirectory(_folder);
        }
        string dateTime = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        string json = GetJson();
        File.WriteAllText(_folder + dateTime + ".json", json);
        CheckHighScore();
    }

    private static void CheckHighScore()
    {
        string highScoreFilePath = _folder + "HIGHSCORE.txt";
        int score = ScoreKeeper.GetScore();
        if (!File.Exists(highScoreFilePath))
        {
            File.WriteAllText(highScoreFilePath, score.ToString());
        }
        else
        {
            int oldHighScore = int.Parse(File.ReadAllText(highScoreFilePath));
            if (oldHighScore < score)
            {
                File.WriteAllText(highScoreFilePath, score.ToString());
            }
        }


    }

    private static string GetJson()
    {
        _gameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        string json = "{";
        int logCount = 0;
        int turtleCount = 0;
        int carCount = 0;
        int homeFrogCount = 0;
        json += Achievements.ToJson();
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
            else if (gameObjectFromArray.name == "ScoreKeeper")
            {
                json += "\"ScoreKeeper\":" + gameObjectFromArray.GetComponent<ScoreKeeper>().ToJson() + ",";
            }
        }

        json = json.Remove(json.Length - 1);
        json += "}";
        return json;
    }
}
