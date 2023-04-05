using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private int _scoreMultiplier = 1; //change this when using a 2x multiplier or something
    private int _score;
    public TextMeshProUGUI scoreMessage;

    public void AddScore(int amount)
    {
        _score += amount * _scoreMultiplier;
        scoreMessage.text = _score.ToString();

    }


    public int GetScore()
    {
        return _score;
    }
}
