using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStateButtonBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    public void OnButtonPress()
    {
        string folder = RootPathStorer.RootPath+ "CurrentGame" + Path.DirectorySeparatorChar + buttonText.text;
        

        TransitionLoader.Instance.LoadTransition(SceneManager.GetActiveScene().buildIndex);

        FolderToLoadFrom.FolderPath = folder;

        
    }
}
