using System;
using System.Collections;
using UnityEngine;

[Serializable()]
public class Achievement
{
    private bool _unlocked;
    private readonly string _name;
    
    [Serializable]
    private struct Data
    {
        public bool isUnlocked;
        public string name;
    }

    public Achievement(string name)
    {
        _name = name;
        _unlocked = false;
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
            isUnlocked = _unlocked,
            name = _name,
        };
        return JsonUtility.ToJson(data);
    }

    
}
