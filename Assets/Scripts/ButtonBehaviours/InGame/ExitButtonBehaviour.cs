using System.IO;
using UnityEngine;
using Directory = System.IO.Directory;

namespace ButtonBehaviours.InGame
{
    public class ExitButtonBehaviour : MonoBehaviour
    {
        public void OnButtonPress()
        {
            string currentGameFolder = RootPathStorer.RootPath +  "CurrentGame" + Path.DirectorySeparatorChar;
            if (Directory.Exists(currentGameFolder))
            {
                Directory.Delete(currentGameFolder, recursive:true);
            }
            TransitionLoader.Instance.LoadTransition(0);
        }
    }
}
