using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Achievement
{
    private bool _unlocked;
    private readonly string _name;
    
    [Serializable]
    private struct Data
    {
        public bool _unlocked;
        public string _name;
    }

    public Achievement(string name)
    {
        _name = name;
        _unlocked = false;
    }
    
    public Achievement(string name, bool unlocked)
    {
        _name = name;
        _unlocked = unlocked;
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

    public string ToJson()
    {
        var data = new Data()
        {
            _unlocked = _unlocked,
            _name = _name,
        };
        return JsonUtility.ToJson(data);
    }

    
}
