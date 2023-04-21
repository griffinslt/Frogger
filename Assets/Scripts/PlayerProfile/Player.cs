public class Player
{
    private int _highestLevelAchieved;
    private string[] _achievementsUnlocked;

    public int GetHighestLevelAchieved()
    {
        //get info from file
        return _highestLevelAchieved;
    }

    public string[] GetUnlockedAchievements()
    {
        //get info from file
        return _achievementsUnlocked;
    }
}
