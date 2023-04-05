using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonBehaviour : MonoBehaviour
{
    public void OnButtonPress()
    {
        if (Time.timeScale == 0)
        {
            Pause();
        }

        else if (Time.timeScale == 1)
        {
            Play();
        }
        print("bring up pause menu");
    }

    private void Pause()
    {
        Time.timeScale = 1;
        
    }

    private void Play()
    {
        Time.timeScale = 0;
    }
}
