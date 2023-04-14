using UnityEngine;
using UnityEngine.SceneManagement;

namespace ButtonBehaviours
{
    public class NewGameButtonBehaviour : MonoBehaviour
    {
        public void OnButtonPress()
        {
            SceneManager.LoadScene("Level1");
            Time.timeScale = 1;
        }
    }
}
