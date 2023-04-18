
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Saver : MonoBehaviour
{
    public static Saver Instance { get; set; }
    private static GameObject[] _gameObjects;
    private static string _folder;
    private static string _dateTimeFolder;
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
        _dateTimeFolder = _folder + dateTime;
        Directory.CreateDirectory(_dateTimeFolder);
        GetJson();
        // File.WriteAllText(_folder + dateTime + ".json", json);
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

    private static void GetJson()
    {
        _gameObjects = FindObjectsOfType<GameObject>() ;
        string json = ".json";
        int logCount = 0;
        int turtleCount = 0;
        int carCount = 0;
        int homeFrogCount = 0;
        string achievementsFolder = Application.dataPath + "/SaveFiles/Achievements";
        if (!Directory.Exists(achievementsFolder))
        {
            Directory.CreateDirectory(achievementsFolder);
        }

        var achievements = Achievements.Get();
        for (int i = 0; i < Achievements.Get().Count; i++)
        {
            string fileName = achievementsFolder + "/Achievement" + i + json;
            File.WriteAllText(fileName, string.Empty);
            File.WriteAllText(fileName, achievements[i].ToJson());
        }
        foreach (var gameObjectFromArray in _gameObjects)
        {
            if (gameObjectFromArray.CompareTag("Log"))
            {
                File.WriteAllText(_dateTimeFolder + "/Log" + logCount + json, 
                    gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson());
                logCount++;
            } else if (gameObjectFromArray.CompareTag("Frog"))
            {
                File.WriteAllText(_dateTimeFolder + "/Frog" + json,
                gameObjectFromArray.GetComponent<FrogMovement>().ToJson());
            }
            else if (gameObjectFromArray.CompareTag("Turtle"))
            {
                File.WriteAllText(_dateTimeFolder + "/Turtle" + turtleCount + json,
                    gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson());
                turtleCount++;
            } else if (gameObjectFromArray.CompareTag("Car"))
            {
                File.WriteAllText(_dateTimeFolder + "/Car" + carCount + json, 
                    gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson());
                carCount++;
            } else if (gameObjectFromArray.CompareTag("HomeFrog"))
            {
                File.WriteAllText(_dateTimeFolder + "/HomeFrog" + homeFrogCount + json, 
                    gameObjectFromArray.GetComponent<HomeFrog>().ToJson());
                homeFrogCount++;
            }
            else if (gameObjectFromArray.name == "ScoreKeeper")
            {
                File.WriteAllText(_dateTimeFolder + "/ScoreKeeper" + json, 
                    gameObjectFromArray.GetComponent<ScoreKeeper>().ToJson());
            }
        }
        
    }
}
