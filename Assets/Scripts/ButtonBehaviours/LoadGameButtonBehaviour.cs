using System;
using System.IO;
using System.Linq;
using PlayerProfile;
using TMPro;
using UnityEngine;



namespace ButtonBehaviours
{
    public class LoadGameButtonBehaviour : MonoBehaviour
    {
        // public static LoadGameButtonBehaviour Instance { get; set; }
        private static string _folder;
        private static string[] _files;
        private GameObject[] loadButtons;
        private static int _level;

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
            _folder = RootPathStorer.RootPath + "Player" + PlayerSelector.SelectedPlayer + "/";
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

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void LoadLevel(int level)
        {
            _level = level;
            ClearButtons();
            string path = _folder + "Level" + _level;
            CreateDirectory(path);
            
            _files = Directory.GetDirectories(path).ToArray();
            Array.Reverse(_files);
            print(_files);
            
            string unlockedLevelFilePath = RootPathStorer.RootPath + "Player" + PlayerSelector.SelectedPlayer + Path.DirectorySeparatorChar+ "unlockedTo.txt";
            string fileContents = File.ReadAllText(unlockedLevelFilePath);
            int unlockedTo;
            if (fileContents.Length < 1)
            {
                unlockedTo = 1;
            }
            else
            {
                unlockedTo = int.Parse(File.ReadAllText(unlockedLevelFilePath));
            }
            
            if (unlockedTo >= level)
            {
                _files = _files.ToList().Prepend(RootPathStorer.RootPath + "Start Of Level").ToArray();
            }
            
            for (int i = 0; i < _files.Length; i++)
            {
                loadButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = Path.GetFileNameWithoutExtension(_files[i]);
                if (i == loadButtons.Length-1)
                {
                    break;
                }
            }
        }
        

        public void LoadSelectedLevel(GameObject button)
        {
            int buttonIndex = int.Parse(button.name);
            if (buttonIndex >= _files.Length)
            {
                return;
            }
            
            switch (_level)
            {
                case 1:
                    TransitionLoader.Instance.LoadTransition(1);
                    break;
                case 2:
                    TransitionLoader.Instance.LoadTransition(2);
                    break;
                case 3:
                    // SceneManager.LoadScene("Level3");
                    // TransitionLoader.Instance.LoadTransition(3);
                    break;
            }
            string chosenFile = _files[buttonIndex];
            FolderToLoadFrom.FolderPath = chosenFile;
        }
        
    
    }
}
