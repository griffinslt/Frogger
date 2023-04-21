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
            const string currentGameFolder = "Assets/SaveFiles/CurrentGame/";
            if (Directory.Exists(currentGameFolder))
            {
                Directory.Delete(currentGameFolder, recursive:true);
            }
            TransitionLoader.Instance.LoadTransition(0);
        }
    }
}
