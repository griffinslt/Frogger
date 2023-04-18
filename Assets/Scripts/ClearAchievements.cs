using UnityEngine;

public class ClearAchievements : MonoBehaviour
{
    public void OnButtonPress()
    {
        var uiAchievements = GameObject.FindGameObjectsWithTag("UIAchievement");
        foreach (var achievement in uiAchievements)
        {
            Destroy(achievement);
        }

        
    }
}
