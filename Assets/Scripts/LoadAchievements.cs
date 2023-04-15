using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadAchievements : MonoBehaviour
{ 
    [SerializeField] private GameObject achievementPrefab;

    [SerializeField] private Sprite newSprite;
    public void OnButtonPress()
    {
        float yCount = 0f;
        // iterate through for each achievement using the achievement prefab to instantiate the objects
        foreach (var achievement in Achievements.Get())
        {
            print(achievement.GetName());
            GameObject newAchievement =Instantiate(achievementPrefab);
            newAchievement.transform.SetParent(GameObject.FindGameObjectWithTag("AchievementsMenu").transform, false);
            newAchievement.GetComponentInChildren<TextMeshProUGUI>().text = achievement.GetName();
            print(achievement.IsUnlocked());
            //change picture when unlocked
            

        }
        
    }

    
}
