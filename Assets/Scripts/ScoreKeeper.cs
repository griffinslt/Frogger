using UnityEngine;
public class ScoreKeeper : MonoBehaviour
{
    private int _score;

    public void AddScore(int amount)
    {
        _score += amount;
    }


    public int GetScore()
    {
        return _score;
    }
}
