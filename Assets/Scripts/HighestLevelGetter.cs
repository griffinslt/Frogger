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
        string filename = "Assets/SaveFiles/Player" + player + "/unlockedTo.txt";
        return File.ReadAllText(filename);
    }
    
    

    
}
