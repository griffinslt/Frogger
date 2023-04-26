using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadAchievements : MonoBehaviour
{ 
    [SerializeField] private GameObject achievementPrefab;

    [SerializeField] private Sprite newSprite;
    
    [SerializeField] private Sprite notAchievedSprite;
    
    
    

    public void OnButtonPress()
    {
        // iterate through for each achievement using the achievement prefab to instantiate the objects
        
        //reload achievements
        AchievementSetter.SetAchievements();
        foreach (var achievement in Achievements.Get())
        {
            
            GameObject newAchievement =Instantiate(achievementPrefab, GameObject.FindGameObjectWithTag("AchievementsMenu").transform, false);
            newAchievement.tag = "UIAchievement";
            if (achievement.IsUnlocked())
            {
                var children = newAchievement.GetComponentsInChildren<Image>();
                foreach (var child in children)
                {
                    if (child.name == "AchievementImage")
                    {
                        child.sprite = newSprite;
                    }
                }
            }
            if (!achievement.IsUnlocked())
            {
                var children = newAchievement.GetComponentsInChildren<Image>();
                foreach (var child in children)
                {
                    if (child.name == "AchievementImage")
                    {
                        child.sprite = notAchievedSprite;
                    }
                }
            }

            

            newAchievement.GetComponentInChildren<TextMeshProUGUI>().text = achievement.GetName();

        }

    }
    
    

    

    
}
