using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLoader : MonoBehaviour
{
    public static TransitionLoader Instance { get; set; }
    public Animator transition;
    public float transitionTime = 1f;
    private static readonly int Start = Animator.StringToHash("Start");

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    public void LoadTransition(int indexOfLevel)
    {
        StartCoroutine(PlayAnimation(indexOfLevel));
    }

    IEnumerator PlayAnimation(int indexOfLevel)
    {
        Time.timeScale = 1;
        transition.SetTrigger(Start);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(indexOfLevel);

    }
}
