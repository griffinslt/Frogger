
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PlayerProfile;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;


public class Saver : MonoBehaviour
{
    public static Saver Instance { get; set; }
    private static GameObject[] _gameObjects;
    private static string _folder;
    private static string _dateTimeFolder;
    private static string _sceneName;

    private void Start()
    {
        InvokeRepeating(nameof(SaveStateForRollBack), 5, 10);
        //when game ends clear this file so it is only ever the current game that is stored there
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
        _sceneName = SceneManager.GetActiveScene().name;
        _folder = RootPathStorer.RootPath + "Player"+ PlayerSelector.SelectedPlayer + Path.DirectorySeparatorChar + SceneManager.GetActiveScene().name + Path.DirectorySeparatorChar;
    }

   


    public void Save()
    {
        print("Saving");
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
        string highScoreFilePath = RootPathStorer.RootPath + SceneManager.GetActiveScene().name + "HIGHSCORE.txt";
        int score = ScoreKeeper.Instance.GetScore();
        if (!File.Exists(highScoreFilePath))
        {
            File.WriteAllText(highScoreFilePath, score + "\n" + PlayerSelector.SelectedPlayer);
        }
        else
        {
            int oldHighScore = int.Parse(File.ReadLines(highScoreFilePath).First());
            if (oldHighScore < score)
            {
                File.WriteAllText(highScoreFilePath, score + "\n" + PlayerSelector.SelectedPlayer);
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
        string achievementsFolder = RootPathStorer.RootPath + "Player"+ PlayerSelector.SelectedPlayer + Path.DirectorySeparatorChar +"Achievements";
        if (!Directory.Exists(achievementsFolder))
        {
            Directory.CreateDirectory(achievementsFolder);
        }

        var achievements = Achievements.Get();
        for (int i = 0; i < Achievements.Get().Count; i++)
        {
            string fileName = achievementsFolder + Path.DirectorySeparatorChar + "Achievement" + i + json;
            File.WriteAllText(fileName, string.Empty);
            File.WriteAllText(fileName, achievements[i].ToJson());
        }
        foreach (var gameObjectFromArray in _gameObjects)
        {
            if (gameObjectFromArray.CompareTag("Log"))
            {
                File.WriteAllText(_dateTimeFolder + Path.DirectorySeparatorChar + "Log" + logCount + json, 
                    gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson());
                logCount++;
            } else if (gameObjectFromArray.CompareTag("Frog"))
            {
                File.WriteAllText(_dateTimeFolder + Path.DirectorySeparatorChar + "Frog" + json,
                gameObjectFromArray.GetComponent<FrogMovement>().ToJson());
            }
            else if (gameObjectFromArray.CompareTag("Turtle"))
            {
                File.WriteAllText(_dateTimeFolder + Path.DirectorySeparatorChar + "Turtle" + turtleCount + json,
                    gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson());
                turtleCount++;
            } else if (gameObjectFromArray.CompareTag("Car"))
            {
                File.WriteAllText(_dateTimeFolder + Path.DirectorySeparatorChar + "Car" + carCount + json, 
                    gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson());
                carCount++;
            } else if (gameObjectFromArray.CompareTag("HomeFrog"))
            {
                File.WriteAllText(_dateTimeFolder + Path.DirectorySeparatorChar + "HomeFrog" + homeFrogCount + json, 
                    gameObjectFromArray.GetComponent<HomeFrog>().ToJson());
                homeFrogCount++;
            }
            else if (gameObjectFromArray.name == "ScoreKeeper")
            {
                File.WriteAllText(_dateTimeFolder + Path.DirectorySeparatorChar + "ScoreKeeper" + json, 
                    gameObjectFromArray.GetComponent<ScoreKeeper>().ToJson());
            }
            else if(gameObjectFromArray.CompareTag("LevelInfo"))
            {
                File.WriteAllText(_dateTimeFolder + Path.DirectorySeparatorChar + "LevelInfo" + json, 
                    gameObjectFromArray.GetComponent<LevelInfo>().ToJson());
            }
            
        }
        
    }
    
    public void SaveStateForRollBack()
    {
        string dateTime = System.DateTime.Now.ToString("HH-mm-ss");
        string currentGameFolder = RootPathStorer.RootPath + "CurrentGame" + Path.DirectorySeparatorChar;
        string folderForRollback = currentGameFolder + dateTime;
        if (!Directory.Exists(folderForRollback))
        {
            Directory.CreateDirectory(folderForRollback);
            print(folderForRollback);
        }
        
        _gameObjects = FindObjectsOfType<GameObject>() ;
        string json = ".json";
        int logCount = 0;
        int turtleCount = 0;
        int carCount = 0;
        int homeFrogCount = 0;
        string achievementsFolder = folderForRollback + Path.DirectorySeparatorChar + "Achievements";
        if (!Directory.Exists(achievementsFolder))
        {
            Directory.CreateDirectory(achievementsFolder);
        }

        var achievements = Achievements.Get();
        for (int i = 0; i < Achievements.Get().Count; i++)
        {
            string fileName = achievementsFolder + Path.DirectorySeparatorChar +"Achievement" + i + json;
            File.WriteAllText(fileName, string.Empty);
            File.WriteAllText(fileName, achievements[i].ToJson());
        }
        foreach (var gameObjectFromArray in _gameObjects)
        {
            if (gameObjectFromArray.CompareTag("Log"))
            {
                File.WriteAllText(folderForRollback + Path.DirectorySeparatorChar + "Log" + logCount + json, 
                    gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson());
                logCount++;
            } else if (gameObjectFromArray.CompareTag("Frog"))
            {
                File.WriteAllText(folderForRollback + Path.DirectorySeparatorChar + "Frog" + json,
                gameObjectFromArray.GetComponent<FrogMovement>().ToJson());
            }
            else if (gameObjectFromArray.CompareTag("Turtle"))
            {
                File.WriteAllText(folderForRollback + Path.DirectorySeparatorChar + "Turtle" + turtleCount + json,
                    gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson());
                turtleCount++;
            } else if (gameObjectFromArray.CompareTag("Car"))
            {
                File.WriteAllText(folderForRollback + Path.DirectorySeparatorChar + "Car" + carCount + json, 
                    gameObjectFromArray.GetComponent<SlidingObjectBehaviour>().ToJson());
                carCount++;
            } else if (gameObjectFromArray.CompareTag("HomeFrog"))
            {
                File.WriteAllText(folderForRollback + Path.DirectorySeparatorChar + "HomeFrog" + homeFrogCount + json, 
                    gameObjectFromArray.GetComponent<HomeFrog>().ToJson());
                homeFrogCount++;
            }
            else if (gameObjectFromArray.name == "ScoreKeeper")
            {
                File.WriteAllText(folderForRollback + Path.DirectorySeparatorChar + "ScoreKeeper" + json, 
                    gameObjectFromArray.GetComponent<ScoreKeeper>().ToJson());
            }
            else if(gameObjectFromArray.CompareTag("LevelInfo"))
            {
                File.WriteAllText(folderForRollback + Path.DirectorySeparatorChar + "LevelInfo" + json, 
                    gameObjectFromArray.GetComponent<LevelInfo>().ToJson());
            }
            
        }
    }
}
