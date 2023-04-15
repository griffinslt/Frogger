using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
   public AchievementManager Instance { get; private set; }

   private readonly Queue<Achievement> _achievementsQ = new();

   public void NotifyAchievementComplete(string nameOfAchievement)
   {
      _achievementsQ.Enqueue(new Achievement(nameOfAchievement));
   }

   private void Start()
   {
      if (Instance)
      {
         Destroy(gameObject);
      }
      else
      {
         Instance = this;
      }
      
      SetAchievements();
      StartCoroutine(nameof(AchievementQueueCheck));
      
   }

   private void UnlockAchievement(Achievement achievement)
   {
      achievement.Unlock();
      Achievements.Add(achievement);
      print(achievement.GetName() + " has been unlocked");
   }

   private IEnumerator AchievementQueueCheck()
   {
      while (true)
      {
         if (_achievementsQ.Count > 0)
         {
            UnlockAchievement(_achievementsQ.Dequeue());
         }

         yield return new WaitForSeconds(5f);
      }
   }
   
   public void SetAchievements()
   {
      Achievements.Add(new Achievement("10 Jumps"));
      Achievements.Add(new Achievement("50 Jumps"));
      Achievements.Add(new Achievement("100 Jumps"));
      Achievements.Add(new Achievement("Level 1 Complete"));
      Achievements.Add(new Achievement("Level 2 Complete"));
      Achievements.Add(new Achievement("Level 3 Complete"));
      Achievements.Add(new Achievement("Completed All Levels"));
   }
}
