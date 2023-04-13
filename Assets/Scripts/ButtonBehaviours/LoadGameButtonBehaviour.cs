using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;


namespace ButtonBehaviours
{
    public class LoadGameButtonBehaviour : MonoBehaviour
    {
        private static string _folder;
        private string[] _files;
        private void Start()
        {
            _folder = Application.dataPath + "/SaveFiles/";
            for (int i = 1; i < 3; i++)
            {
                if (!Directory.Exists(_folder))
                {
                    Directory.CreateDirectory(_folder + "Level" + i);
                }
            }
        }

        public void SaveLevel1()
        {

            string[] files = Directory.EnumerateFiles(_folder + "Level1", "*.json").ToArray();
            Array.Reverse(files);
            var loadButtons = GameObject.FindGameObjectsWithTag("LoadLevelButton");
            for (int i = 0; i < files.Length; i++)
            {
                loadButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = Path.GetFileNameWithoutExtension(files[i]);
                if (i == loadButtons.Length-1)
                {
                    break;
                }
            }
        }
        
        public void SaveLevel2()
        {
            
        }
        
        public void SaveLevel3()
        {
            
        }
    
    }
}
