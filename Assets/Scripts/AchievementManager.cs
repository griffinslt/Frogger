using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
   public AchievementManager Instance { get; private set; }

   [SerializeField] private GameObject[] achievementUI;

   private static readonly Queue<Achievement> AchievementsQ = new();

   public void NotifyAchievementComplete(Achievement achievement)
   {
      AchievementsQ.Enqueue(achievement);
   }

   private void Start()
   {
      if (Instance != null && Instance != this) 
      {
         Destroy(this); 
      } 
      else 
      { 
         Instance = this; 
      }
      StartCoroutine(nameof(AchievementQueueCheck));
   }

   private void UnlockAchievement(Achievement achievement)
   {
      achievement.Unlock();
      Achievements.Add(achievement);
      RunUnlockAchievementAnimation(achievement.GetName());
   }

   private void RunUnlockAchievementAnimation(string achievementName)
   {
      switch (achievementName)
      {
         case "10 Jumps":
            achievementUI[0].SetActive(true);
            break;
         case "50 Jumps":
            achievementUI[1].SetActive(true);
            break;
         case "100 Jumps":
            achievementUI[2].SetActive(true);
            break;
         case "Level 1 Complete":
            achievementUI[3].SetActive(true);
            break;
         case "Level 2 Complete":
            achievementUI[4].SetActive(true);
            break;
         case "Level 3 Complete":
            achievementUI[5].SetActive(true);
            break;
         case "Completed All Levels":
            achievementUI[6].SetActive(true);
            break;
      }
   }

   private IEnumerator AchievementQueueCheck()
   {
      while (true)
      {
         if (AchievementsQ.Count > 0)
         {
            UnlockAchievement(AchievementsQ.Dequeue());
         }
         yield return new WaitForSeconds(5f);
         foreach (var achievementInUI in achievementUI)
         {
            achievementInUI.SetActive(false);
         }
         
      }
   }
   
   
}
