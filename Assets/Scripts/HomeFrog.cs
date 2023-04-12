using System;
using UnityEngine;
[Serializable]
public class HomeFrog : MonoBehaviour
{
    [Serializable]
    private struct HomeFrogData
    {
        public float PositionX;
        public float PositionY;
        //Todo figure out how score keeper and homefrog spawner can stay connected - home frog spawner can be static
    }
    
    
    public string ToJson()
    {
        var position = transform.position;
        var data = new HomeFrogData()
        {
            PositionX = position.x,
            PositionY = position.y,
        };
        return JsonUtility.ToJson(data);
    }
    
}


