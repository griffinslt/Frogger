using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class HomeFrog : MonoBehaviour
{
    public static int NumberOfHomeFrogs; 
    [Serializable]
    private struct HomeFrogData
    {
        public float PositionX;
        public float PositionY;
        //Todo figure out how score keeper and homefrog spawner can stay connected - home frog spawner can be static
    }

    private void Awake()
    {
        NumberOfHomeFrogs++;
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


