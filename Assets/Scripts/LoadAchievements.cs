using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadAchievements : MonoBehaviour
{ 
    [SerializeField] private GameObject achievementPrefab;

    [SerializeField] private Sprite newSprite;

    private void Start()
    {
        SetAchievements();
    }

    public void OnButtonPress()
    {
        // iterate through for each achievement using the achievement prefab to instantiate the objects
        foreach (var achievement in Achievements.Get())
        {
            GameObject newAchievement =Instantiate(achievementPrefab);
            newAchievement.tag = "UIAchievement";
            if (achievement.IsUnlocked())
            {
                print(achievement.GetName() + " is unlocked");
                var children = newAchievement.GetComponentsInChildren<Image>();
                foreach (var child in children)
                {
                    if (child.name == "AchievementImage")
                    {
                        child.sprite = newSprite;
                    }
                }
            }
            newAchievement.transform.SetParent(GameObject.FindGameObjectWithTag("AchievementsMenu").transform, false);
            newAchievement.GetComponentInChildren<TextMeshProUGUI>().text = achievement.GetName();
            //change picture when unlocked
            
        }

    }
    
    public void SetAchievements()
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
