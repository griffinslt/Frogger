using UnityEngine;
using UnityEngine.SceneManagement;

namespace ButtonBehaviours.InGame
{
    public class ExitButtonBehaviour : MonoBehaviour
    {
        public void OnButtonPress()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
