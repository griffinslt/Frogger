using UnityEngine;

public class PauseButtonBehaviour : MonoBehaviour
{
    public void OnButtonPress()
    {
        Time.timeScale = 0;

    }
}
