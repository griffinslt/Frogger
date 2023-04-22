using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class StateButtonLoader : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    private void OnEnable()
    {
        string folderPath = "Assets/SaveFiles/CurrentGame";
        string[] folders = Directory.GetDirectories(folderPath);
        foreach (var folder in folders.Reverse())
        {
            GameObject newButton = Instantiate(buttonPrefab, GameObject.FindGameObjectWithTag("ButtonContainer").transform, false);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = Path.GetFileName(folder);
        }

    }
}
