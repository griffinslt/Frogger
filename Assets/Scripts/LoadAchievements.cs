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

    

    
}
