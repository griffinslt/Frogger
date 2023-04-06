using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public static LevelInfo Instance { get; set; }

    private static int _timeForLevel = 150;

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
