using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace ButtonBehaviours
{
    public class LoadGameButtonBehaviour : MonoBehaviour
    {
        // public static LoadGameButtonBehaviour Instance { get; set; }
        private static string _folder;
        private static string[] _files;
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

        public void LoadLevel1()
        {

            _files = Directory.EnumerateFiles(_folder + "Level1", "*.json").ToArray();
            Array.Reverse(_files);
            var loadButtons = GameObject.FindGameObjectsWithTag("LoadLevelButton");
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
            
        }
        
        public void LoadLevel3()
        {
            
        }

        public void LoadSelectedLevel(GameObject button)
        {
            int buttonIndex = int.Parse(button.name);
            if (buttonIndex >= _files.Length)
            {
                return;
            }
            string chosenFile = _files[buttonIndex];
            print(chosenFile);

        }
    
    }
}
