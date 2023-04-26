using UnityEngine;
using UnityEngine.SceneManagement;

namespace ButtonBehaviours
{
    public class RetryLevelButton : MonoBehaviour
    {
        public void OnButtonPress()
        {
            FolderToLoadFrom.FolderPath =  RootPathStorer.RootPath + "Start Of Level";
            SlidingObjectBehaviour._ids = 0;
            HomeFrog.NumberOfHomeFrogs = 0;
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            TransitionLoader.Instance.LoadTransition(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}
