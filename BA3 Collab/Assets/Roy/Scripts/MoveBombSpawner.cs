using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBombSpawner : MonoBehaviour
{
    public LayerMask objLayer;
    public float maxDistance;
    public float spawnDistance;

    private void FixedUpdate()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.right,out hitInfo,maxDistance, objLayer)) 
        {
          float distance= Vector3.Distance(hitInfo.point, transform.position);
          transform.position = new Vector3(transform.position.x + distance - spawnDistance, transform.position.y, transform.position.z);
        }
    }
}
