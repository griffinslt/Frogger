using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class AchievementSetter : MonoBehaviour
{
    private void Start()
    {
        SetAchievements();
    }

    private static void SetAchievements()
    {
        var achievementFiles = Directory.EnumerateFiles( "Assets/SaveFiles/Achievements" , "*.json").ToArray();
        Achievements.Clear();
        foreach (var file in achievementFiles)
        {
            string achievementJson = File.ReadAllText(file);
            // print(achievementJson);
            var jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(achievementJson);
            Achievements.Add(new Achievement(jsonDictionary["_name"], bool.Parse(jsonDictionary["_unlocked"])));
        }
        
    }
}
