using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonBehaviour : MonoBehaviour
{
    public void OnButtonPress()
    {
        Application.Quit();
    }
}
