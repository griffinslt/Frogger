using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PlayerProfile;
using UnityEngine;

public class AchievementSetter : MonoBehaviour
{
    private void OnEnable()
    {
        SetAchievements();
    }

    public static void SetAchievements()
    {
        string filepath = RootPathStorer.RootPath+ "Player" + PlayerSelector.SelectedPlayer + Path.DirectorySeparatorChar + "Achievements";
        print(filepath);
        if (!Directory.Exists(filepath))
        {
            Achievements.Clear();
            Achievements.Add(new Achievement("100 Jumps"));
            Achievements.Add(new Achievement("250 Jumps"));
            Achievements.Add(new Achievement("500 Jumps"));
            Achievements.Add(new Achievement("Level 1 Complete"));
            Achievements.Add(new Achievement("Level 2 Complete"));
            Achievements.Add(new Achievement("Level 3 Complete"));
            Achievements.Add(new Achievement("Completed All Levels"));
        }
        else
        {
            var achievementFiles = Directory.EnumerateFiles(filepath, "*.json").ToArray();
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
}
