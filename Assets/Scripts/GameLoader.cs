using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using Object = System.Object;

public class GameLoader : MonoBehaviour
{
    public static GameLoader Instance { get; set; }
    public JsonObject jsonFile;


    private void Start()
    {
        LoadFile("/Users/samuelgriffin/Documents/Uni/CSC384/Frogger/Frogger-CSC384/Assets/SaveFiles/Level1/2023-04-17-17-36-59.json");
    }

    private void LoadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }

        string json = File.ReadAllText(filePath);
        print(json);

    }
}
