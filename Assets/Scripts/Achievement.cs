using System.Collections;

public class Achievement
{
    private bool _unlocked;
    private readonly string _name;

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

    public string GetName()
    {
        return _name;
    }
}
