using UnityEngine;

public class Bar : MonoBehaviour
{
    public GameObject bar;

    public int time;

    void Start()
    {
        time = LevelInfo.GetTime();
        AnimateBar();
    }
    
    private void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time).setOnComplete(GameOver);
    }

    private void GameOver()
    {
        print("GameOver");
    }
}
