using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ButtonBehaviours
{
    public class LoadGameButtonBehaviour : MonoBehaviour
    {
        // public static LoadGameButtonBehaviour Instance { get; set; }
        private static string _folder;
        private static string[] _files;
        private GameObject[] loadButtons;
        private static int level;

        private void Start()
        {
            
            // if (Instance != null && Instance != this) 
            // {
            //     Destroy(this); 
            // } 
            // else 
            // { 
            //     Instance = this; 
            // }
            _folder = Application.dataPath + "/SaveFiles/";
            for (int i = 1; i < 3; i++)
            {
                if (!Directory.Exists(_folder))
                {
                    Directory.CreateDirectory(_folder + "Level" + i);
                }
            }
        }

        private void Awake()
        {
            
        }

        private void ClearButtons()
        {
            loadButtons = GameObject.FindGameObjectsWithTag("LoadLevelButton");
            foreach (var button in loadButtons)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = "No Save Data";
            }
        }

        public void LoadLevel1()
        {
            level = 1;
            ClearButtons();
            _files = Directory.EnumerateFiles(_folder + "Level1", "*.json").ToArray();
            Array.Reverse(_files);
            //loadButtons = GameObject.FindGameObjectsWithTag("LoadLevelButton");
            for (int i = 0; i < _files.Length; i++)
            {
                loadButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = Path.GetFileNameWithoutExtension(_files[i]);
                if (i == loadButtons.Length-1)
                {
                    break;
                }
            }
        }
        
        public void LoadLevel2()
        {
            level = 2;
            ClearButtons();
        }
        
        public void LoadLevel3()
        {
            level = 3;
            ClearButtons();
        }

        public void LoadSelectedLevel(GameObject button)
        {
            int buttonIndex = int.Parse(button.name);
            if (buttonIndex >= _files.Length)
            {
                return;
            }
            
            switch (level)
            {
                case 1:
                    SceneManager.LoadScene("Level1");
                    break;
                case 2:
                    // SceneManager.LoadScene("Level2");
                    break;
                case 3:
                    // SceneManager.LoadScene("Level3");
                    break;
            }
            string chosenFile = _files[buttonIndex];
            //this should actually be the chosen game folder
            // GameLoader gameLoader = gameObject.AddComponent<GameLoader>();
            // GameLoader.Instance.LoadFile("/Users/samuelgriffin/Documents/Uni/CSC384/Frogger/Frogger-CSC384/Assets/SaveFiles/Level1/2023-04-18-20-08-18");
            FolderToLoadFrom.folderPath =
                "/Users/samuelgriffin/Documents/Uni/CSC384/Frogger/Frogger-CSC384/Assets/SaveFiles/Level1/2023-04-20-12-01-49";
        }
    
    }
}
