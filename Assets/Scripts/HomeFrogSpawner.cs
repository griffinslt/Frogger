using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomeFrogSpawner : MonoBehaviour
{
   [SerializeField] private GameObject homeFrog;
   public void SpawnHomeFrog(Transform otherTransform)
   {
      Instantiate(homeFrog, otherTransform.position, otherTransform.rotation);
   }
    
    
}
