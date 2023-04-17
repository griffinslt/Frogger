using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSetter : MonoBehaviour
{
    private void Start()
    {
        SetAchievements();
    }

    private static void SetAchievements()
    {
        Achievements.Clear();
        Achievements.Add(new Achievement("10 Jumps"));
        Achievements.Add(new Achievement("50 Jumps"));
        Achievements.Add(new Achievement("100 Jumps"));
        Achievements.Add(new Achievement("Level 1 Complete"));
        Achievements.Add(new Achievement("Level 2 Complete"));
        Achievements.Add(new Achievement("Level 3 Complete"));
        Achievements.Add(new Achievement("Completed All Levels"));
    }
}
