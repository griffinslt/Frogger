using System.Collections;

public class Achievement
{
    public static ArrayList Achievements;
    private bool _unlocked;
    private string _name;

    public Achievement(string name)
    {
        _name = name;
    }

    public bool IsUnlocked()
    {
        return _unlocked;
    }

    public void Unlock()
    {
        _unlocked = true;
    }
}
