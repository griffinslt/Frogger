using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public GameObject bar;

    public int time;
    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
        
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
