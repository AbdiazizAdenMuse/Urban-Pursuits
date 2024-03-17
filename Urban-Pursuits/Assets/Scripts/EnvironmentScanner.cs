using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnvironmentScanner : MonoBehaviour
{
    [SerializeField] Vector3 forwardRayOffset = new Vector3(0, 2.5f, 0);
    [SerializeField] float forwardRayLength = 0.8f;
    [SerializeField] LayerMask obstaclelayer;
    public ObstacleHitData ObstacleCheck()
    {
        var hitData = new ObstacleHitData();
        var forwardOrigin = transform.position + forwardRayOffset;
        hitData.forwardHitFound = Physics.Raycast(forwardOrigin
          , transform.forward, out hitData.forwardHit ,
          forwardRayLength, obstaclelayer);

        Debug.DrawRay(forwardOrigin, transform.forward * forwardRayLength, (hitData.forwardHitFound) ? Color.red : Color.white);
        return hitData;
    }
}
public struct ObstacleHitData{
    public bool forwardHitFound;
    public RaycastHit forwardHit;
}
