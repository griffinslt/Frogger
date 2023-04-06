using System;
using UnityEngine;
[Serializable]
public class LevelInfo : MonoBehaviour
{
    public static LevelInfo Instance { get; set; }

    [SerializeField]private static int _timeForLevel = 5;

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

    public static int GetTime()
    {
        return _timeForLevel;
    }
}
