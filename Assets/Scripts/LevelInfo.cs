using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    private static int _timeForLevel;


    public static int GetTime()
    {
        return _timeForLevel;
    }
}
