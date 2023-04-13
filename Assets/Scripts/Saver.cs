
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        
        FOLDER = Application.dataPath + "/SaveFiles/" +  SceneManager.GetActiveScene().name + "/"; 
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
        CheckHighScore();
    }

    private static void CheckHighScore()
    {
        /*
         * Check if highs core file exists for level
         * if it doesn't create the score and get the score for score keeper and save it
         * if it already exists read in file and see if the number scored is greater
         * (I think just text file is fine - json if you decide to have profiles)
         * If score from score keeper is greater, clear file and write new score instead
         */

        string highScoreFilePath = FOLDER + "HIGHSCORE.txt";
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
