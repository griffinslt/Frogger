using System;
using System.IO;
using PlayerProfile;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

[Serializable]
public class LevelInfo : MonoBehaviour
{
    public static LevelInfo Instance { get; set; }

    private static int _timeForLevel = 100;
    [SerializeField] private int maxNumberOfHomeFrogs = 4;

    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject frog;

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
        if (HomeFrog.NumberOfHomeFrogs > maxNumberOfHomeFrogs)
        {
            Win();
        }
    }

    private void Win()
    {
        Time.timeScale = 0;
        Saver.Instance.Save();
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
        frog.GetComponent<FrogMovement>().DidFrogDie();
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
