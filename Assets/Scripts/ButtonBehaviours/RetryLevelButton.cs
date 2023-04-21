using UnityEngine;
using UnityEngine.SceneManagement;

namespace ButtonBehaviours
{
    public class RetryLevelButton : MonoBehaviour
    {
        public void OnButtonPress()
        {
            FolderToLoadFrom.folderPath = "Assets/SaveFiles/Base";
            SlidingObjectBehaviour._ids = 0;
            HomeFrog.NumberOfHomeFrogs = 0;
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            TransitionLoader.Instance.LoadTransition(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}
