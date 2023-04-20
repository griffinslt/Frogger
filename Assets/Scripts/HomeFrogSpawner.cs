using System;
using UnityEngine;


public class HomeFrogSpawner : MonoBehaviour
{
   public static HomeFrogSpawner Instance { get; set; }
   [SerializeField] private GameObject homeFrog;

   private void Awake()
   {
      if (Instance != null && Instance != this) 
      {
          Destroy(this); 
      } 
      else 
      { 
          Instance = this; 
      }
   }

   
   public void SpawnHomeFrog(Transform otherTransform)
   {
      Instantiate(homeFrog, otherTransform.position, otherTransform.rotation);
   }
    
    
}
