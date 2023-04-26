using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Directory = System.IO.Directory;

namespace ButtonBehaviours.InGame
{
    public class ExitButtonBehaviour : MonoBehaviour
    {
        public void OnButtonPress()
        {
            // SceneManager.LoadScene("Menu");
            string currentGameFolder = RootPathStorer.RootPath +  "CurrentGame" + Path.DirectorySeparatorChar;
            if (Directory.Exists(currentGameFolder))
            {
                Directory.Delete(currentGameFolder, recursive:true);
            }
            TransitionLoader.Instance.LoadTransition(0);
        }
    }
}
