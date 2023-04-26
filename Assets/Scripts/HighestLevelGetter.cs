using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class HighestLevelGetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI p1HighLevel;
    [SerializeField] private TextMeshProUGUI p2HighLevel;
    void OnEnable()
    {
        p1HighLevel.text = GetPlayerHighLevel("1");
        p2HighLevel.text = GetPlayerHighLevel("2");

    }

    private string GetPlayerHighLevel(string player)
    {
        string folder = RootPathStorer.RootPath + "Player" + player + Path.DirectorySeparatorChar;
        string file = folder + "unlockedTo.txt";
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);

        }

        if (!File.Exists(file))
        {
            return "1";

        }
        return File.ReadAllText(file);
    }
    
    

    
}
