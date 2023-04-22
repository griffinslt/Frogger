using UnityEngine;
using UnityEngine.SceneManagement;

namespace ButtonBehaviours
{
    public class NextLevelButton : MonoBehaviour
    {
        public void OnButtonPress()
        {
            var level = SceneManager.GetActiveScene().buildIndex;
            LevelInfo.ChangeTimeForLevel(LevelInfo.GetTime() - 20);
            TransitionLoader.Instance.LoadTransition(level + 1);
            HomeFrog.NumberOfHomeFrogs = 0;
            

        }
    }
}
    
