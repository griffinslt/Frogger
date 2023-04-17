using System.Collections.Generic;
using System.Linq;

public static class Achievements
{
    private static readonly List<Achievement> AchievementsList = new List<Achievement>();

    public static void Add(Achievement newAchievement)
    {
        bool found = AchievementsList.Any(achievement => achievement.GetName() == newAchievement.GetName());

        if (!found)
        {
            AchievementsList.Add(newAchievement);
        }
    }

    public static List<Achievement> Get()
    {
        return AchievementsList;
    }

    public static Achievement FindAchievementByName(string name)
    {
        foreach (var achievement in AchievementsList.Where(achievement => achievement.GetName() == name))
        {
            return achievement;
        }

        throw new KeyNotFoundException();
    }

    public static void Clear()
    {
        AchievementsList.Clear();
    }
    
    




}
