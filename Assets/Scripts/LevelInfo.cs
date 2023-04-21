using System;
using System.IO;
using PlayerProfile;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class LevelInfo : MonoBehaviour
{
    public static LevelInfo Instance { get; set; }

    private static int _timeForLevel = 100;
    private int _maxNumberOfHomeFrogs = 4;

    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject loseMenu;

    private struct LevelInfoData
    {
        public int DataTimeForLevel;
        public int CurrentTime;
    }

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

    private void Update()
    {
        if (HomeFrog.NumberOfHomeFrogs > _maxNumberOfHomeFrogs)
        {
            Win();
        }
    }

    private void Win()
    {
        Time.timeScale = 0;
        gameMenu.SetActive(false);
        winMenu.SetActive(true); // they have got the high score for the level 
        string currentLevelStr = SceneManager.GetActiveScene().name;
        int currentLevel = int.Parse(currentLevelStr.Substring(currentLevelStr.Length - 1));
        string filename = "Assets/SaveFiles/Player" + PlayerSelector.SelectedPlayer + "/unlockedTo.txt";
        if (File.Exists(filename))
        {
            int oldLevel = int.Parse(File.ReadAllText(filename));
            if (currentLevel >= oldLevel)
            {
                File.WriteAllText(filename, (currentLevel + 1).ToString());
            }
        }
    }

    public void Lose()
    {
        Time.timeScale = 0;
        gameMenu.SetActive(false);
        loseMenu.SetActive(true);
    }

    public static void Load(int timeForLevel, int currentTime)
    {
        _timeForLevel = timeForLevel - currentTime;
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
