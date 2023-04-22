using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance { get; set; }
    private int _scoreMultiplier = 1; //change this when using a 2x multiplier or something
    private int _score;
    public TextMeshProUGUI scoreMessage;

    private struct ScoreData
    {
        public int ScoreMultiplier;
        public int Score;
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

    public void Load(int score, int scoreMultiplier)
    {
        _score = score;
        _scoreMultiplier = scoreMultiplier;
        scoreMessage.text = _score.ToString();
    }

    public void AddMultiplier(int amount)
    {
        _scoreMultiplier *= amount;
    }

    public void AddScore(int amount)
    {
        _score += amount * _scoreMultiplier;
        scoreMessage.text = _score.ToString();
    }


    public int GetScore()
    {
        return _score;
    }

    public string ToJson()
    {
        var data = new ScoreData()
        {
            ScoreMultiplier = _scoreMultiplier,
            Score = _score,
        };
        return JsonUtility.ToJson(data);
    }
}
