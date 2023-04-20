using System;
using UnityEngine;
[Serializable]
public class LevelInfo : MonoBehaviour
{
    public static LevelInfo Instance { get; set; }

    private static int _timeForLevel = 100;

    private struct LevelInfoData
    {
        public int DataTimeForLevel;
        public int CurrentTime;
    }

    private void Start()
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
    

    public string ToJson()
    {
        var data = new LevelInfoData()
        {
            DataTimeForLevel = _timeForLevel,
            CurrentTime = (int)Time.time
        };
        return JsonUtility.ToJson(data);
    }
}
