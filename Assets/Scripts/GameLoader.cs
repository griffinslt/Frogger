using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using Newtonsoft.Json;



public class GameLoader : MonoBehaviour
{
    public static GameLoader Instance { get; set; }
    public JsonObject jsonFile;
    


    private void Start()
    {
        LoadFile("/Users/samuelgriffin/Documents/Uni/CSC384/Frogger/Frogger-CSC384/Assets/SaveFiles/Level1/2023-04-18-15-37-18");
    }

    private void LoadFile(string folder)
    {
        if (!Directory.Exists(folder))
        {
            throw new DirectoryNotFoundException();
        }
        
        var files = Directory.EnumerateFiles( folder, "*.json").ToArray();

        foreach (var file in files)
        {
            // print(file);
        }
        
        
        
        //Load Achievements
        var achievementFiles = Directory.EnumerateFiles( "Assets/SaveFiles/Achievements" , "*.json").ToArray();
        Achievements.Clear();
        foreach (var file in achievementFiles)
        {
            string achievementJson = File.ReadAllText(file);
            // print(achievementJson);
            var jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(achievementJson);
            Achievements.Add(new Achievement(jsonDictionary["_name"], bool.Parse(jsonDictionary["_unlocked"])));
        }

        
        
        
        
        
        
;







    }
}
