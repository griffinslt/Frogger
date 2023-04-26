using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;


public class GameLoader : MonoBehaviour
{
    public static GameLoader Instance { get; set; }
    [SerializeField] public GameObject frog;
    [SerializeField] public GameObject log;
    [SerializeField] public GameObject car;
    [SerializeField] public GameObject turtle;
    [SerializeField] public GameObject homeFrog;

    

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
        SlidingObjectBehaviour._ids = 0;
        StartCoroutine(WaitBeforeLoad());
        LoadFile(FolderToLoadFrom.FolderPath);
        SlidingObjectBehaviour._ids = 0;
    }

    private IEnumerator WaitBeforeLoad()
    {
        yield return new WaitForSeconds(2);
    }

    public void LoadFile(string folder)
    {
        print(folder);
        AchievementSetter.SetAchievements();
        //loop through all game objects are remove the ones that will be changed
        if (!Directory.Exists(folder))
        {
            throw new DirectoryNotFoundException();
        }
        
        var files = Directory.EnumerateFiles( folder, "*.json").ToArray();
        var enumerable = files.Reverse();

        foreach (var file in enumerable)
        {
            SlidingObjectBehaviour._ids = 3;
            string filename = Path.GetFileNameWithoutExtension(file);
            string fileJson = File.ReadAllText(file);
            var jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileJson);
            //Move Frog
            if (filename.Equals("Frog"))
            {
                try
                {
                    var frogX = float.Parse(jsonDictionary["CurrentPositionX"]);
                    var frogY = float.Parse(jsonDictionary["CurrentPositionY"]);
                    var furthestTraveled = int.Parse(jsonDictionary["_furthestTraveled"]);
                    var speed = float.Parse(jsonDictionary["speed"]);
                    var withLadyFrog = bool.Parse(jsonDictionary["_withLadyFrog"]);
                    var onPlatform = bool.Parse(jsonDictionary["_onPlatform"]);
                    var numberOfJumps = int.Parse(jsonDictionary["_numberOfJumps"]);
                    var died = bool.Parse(jsonDictionary["_died"]);
                    var position = new Vector2(frogX, frogY);
                    var frogScript = frog.GetComponent<FrogMovement>();
                    frogScript.LoadData(speed, position,  onPlatform, furthestTraveled,withLadyFrog, numberOfJumps, died);
                }
                catch (KeyNotFoundException e)
                {
                    print(e);
                }
            }

            if (filename.Contains("Log"))
            {
                var speed = float.Parse(jsonDictionary["speed"]);
                if (speed > 0)
                {
                    var ids = int.Parse(jsonDictionary["_ids"]);
                    var id = int.Parse(jsonDictionary["id"]);
                    var position = new Vector2(float.Parse(jsonDictionary["currentX"]),
                        float.Parse(jsonDictionary["currentY"]));
                    var rotation = new Quaternion(0, 0, 0, 0);
                    var newLog = Instantiate(log, position, rotation);
                    newLog.name = "clone";
                    var logScript = log.GetComponent<SlidingObjectBehaviour>();
                    logScript.Load(speed, ids, id);
                }
            }

            if (filename.Contains("Turtle"))
            {
                var speed = float.Parse(jsonDictionary["speed"]);
                if (speed > 0)
                {
                    var ids = int.Parse(jsonDictionary["_ids"]);
                    var id = int.Parse(jsonDictionary["id"]);
                    var position = new Vector2(float.Parse(jsonDictionary["currentX"]),
                        float.Parse(jsonDictionary["currentY"]));
                    var rotation = new Quaternion(0, 0, 180, 0);
                    var newTurtle = Instantiate(turtle, position, rotation);
                    newTurtle.name = "clone";
                    var turtleScript = turtle.GetComponent<SlidingObjectBehaviour>();
                    turtleScript.Load(speed, ids, id);
                }
            }

            if (filename.Contains("Car"))
            {
                var speed = float.Parse(jsonDictionary["speed"]);
                if (speed > 0)
                {
                    var ids = int.Parse(jsonDictionary["_ids"]);
                    var id = int.Parse(jsonDictionary["id"]);
                    var position = new Vector2(float.Parse(jsonDictionary["currentX"]),
                        float.Parse(jsonDictionary["currentY"]));
                    var side = int.Parse(jsonDictionary["startingSide"]);
                    Quaternion rotation;
                    if (side == 2)
                    {
                        rotation = new Quaternion(0, 0, 180, 0);
                    }
                    else
                    {
                        rotation = new Quaternion(0, 0, 0, 0);
                    }

                    var newCar = Instantiate(car, position, rotation);
                    newCar.name = "clone";
                    var carScript = car.GetComponent<SlidingObjectBehaviour>();
                    carScript.Load(speed, ids, id);
                }
            } 
            if (filename.Equals("ScoreKeeper"))
            {
                var scoreDictionary = JsonConvert.DeserializeObject<Dictionary<string, int>>(fileJson);
                ScoreKeeper.Instance.Load(scoreDictionary["Score"], scoreDictionary["ScoreMultiplier"]);
            }

            if (filename.Contains("HomeFrog"))
            {
                var homeFrogDictionary = JsonConvert.DeserializeObject<Dictionary<string, float>>(fileJson);
                var x = homeFrogDictionary["PositionX"];
                var y = homeFrogDictionary["PositionY"];
                var position = new Vector2(x, y);
                if (y > 0)
                {
                    var homes = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.Contains("Home_"));
                    foreach (var home in homes)
                    {
                        var homePosition = home.transform.position;
                        int homeX = (int) homePosition.x;
                        int homeY = (int) homePosition.y;
                        if ( homeX == (int) x && homeY == (int) y)
                        {
                            var homeScript = home.GetComponent<Home>();
                            homeScript.Visit();
                        }
                    }
                    
                    
                    Instantiate(homeFrog, position, new Quaternion(0, 0, 0, 0));
                }
            }

            if (filename.Equals("LevelInfo"))
            {
                var levelDictionary = JsonConvert.DeserializeObject<Dictionary<string, int>>(fileJson);
                LevelInfo.Load(levelDictionary["DataTimeForLevel"], levelDictionary["CurrentTime"]);
                Time.timeScale = 1;
            }
            SlidingObjectBehaviour._ids = 0;   
        }

    }
}
