using UnityEngine;
using UnityEngine.SceneManagement;

namespace ButtonBehaviours
{
    public class NewGameButtonBehaviour : MonoBehaviour
    {
        public void OnButtonPress()
        {
            FolderToLoadFrom.folderPath = "Assets/SaveFiles/Base";
            SlidingObjectBehaviour._ids = 0;
            HomeFrog.NumberOfHomeFrogs = 0;
            TransitionLoader.Instance.LoadTransition(1);
            //SceneManager.LoadScene("Level1");
            Time.timeScale = 1;
        }
        
    }
}
