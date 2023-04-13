using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ButtonBehaviours
{
    public class LoadGameButtonBehaviour : MonoBehaviour
    {
        private static string _folder;

        

        private void Awake()
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
            foreach (var file in files) 
            {
                print(file);
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
