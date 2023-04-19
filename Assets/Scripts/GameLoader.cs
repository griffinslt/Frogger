using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;


public class GameLoader : MonoBehaviour
{
    public static GameLoader Instance { get; set; }
    [SerializeField] public GameObject frog;
    [SerializeField] public GameObject log;
    [SerializeField] public GameObject car;
    [SerializeField] public GameObject turtle;

    private void Start()
    {
        LoadFile(FolderToLoadFrom.folderPath);
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

    public void LoadFile(string folder)
    {
        //loop through all game objects are remove the ones that will be changed
        if (!Directory.Exists(folder))
        {
            throw new DirectoryNotFoundException();
        }
        
        var files = Directory.EnumerateFiles( folder, "*.json").ToArray();

        foreach (var file in files)
        {
            string filename = Path.GetFileNameWithoutExtension(file);
            string fileJson = File.ReadAllText(file);
            var jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileJson);
            //Move Frog
            if (filename.Equals("Frog"))
            {
                
                var frogX = float.Parse(jsonDictionary["CurrentPositionX"]);
                var frogY = float.Parse(jsonDictionary["CurrentPositionY"]);
                var furthestTraveled = int.Parse(jsonDictionary["_furthestTraveled"]);
                var speed = float.Parse(jsonDictionary["speed"]);
                var withLadyFrog = bool.Parse(jsonDictionary["_withLadyFrog"]);
                var onPlatform = bool.Parse(jsonDictionary["_onPlatform"]);
                var numberOfJumps = int.Parse(jsonDictionary["_numberOfJumps"]);
                var position = new Vector2(frogX, frogY);
                var frogScript = frog.GetComponent<FrogMovement>();
                frogScript.LoadData(speed, position,  onPlatform, furthestTraveled,withLadyFrog, numberOfJumps);
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
                    Instantiate(log, position, rotation);
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
                    var side = 2;
                    Instantiate(turtle, position, rotation);
                    var turtleScript = turtle.GetComponent<SlidingObjectBehaviour>();
                    turtleScript.Load(speed, ids, id);
                    // turtleScript.SetDirection(side);
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
                    var rotation = new Quaternion(0, 0, 180, 0);
                    var side = int.Parse(jsonDictionary["startingSide"]);
                    Instantiate(car, position, rotation);
                    var carScript = car.GetComponent<SlidingObjectBehaviour>();
                    carScript.Load(speed, ids, id);
                    // turtleScript.SetDirection(side);
                }
            }
            
            

            

        }
        
        
        
        

        
        
        
        
        
        
;







    }
}
