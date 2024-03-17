using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourController : MonoBehaviour
{
   EnvironmentScanner environmentScanner; 
   private void Awake() {
    environmentScanner = GetComponent<EnvironmentScanner>();
   }

   private void Update() {
  var hitData =  environmentScanner.ObstacleCheck();
  if(hitData.forwardHitFound){
    Debug.Log("Obstacle Found" + hitData.forwardHit.transform.name);
  }
   }
}
