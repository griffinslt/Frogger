using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStateButtonBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    public void OnButtonPress()
    {
        string folder = "Assets/SaveFiles/CurrentGame/" + buttonText.text;
        
        SlidingObjectBehaviour._ids = 0;
        TransitionLoader.Instance.LoadTransition(SceneManager.GetActiveScene().buildIndex);
        SlidingObjectBehaviour._ids = 0;
        FolderToLoadFrom.folderPath = folder;
        SlidingObjectBehaviour._ids = 0;
        
    }
}
