using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    CharDeathSpawnPoint[] spawnPoints;

    // Update is called once per frame
    private void Start()
    {
        spawnPoints = FindObjectsOfType<CharDeathSpawnPoint>();
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            if (spawnPoints.Length != 0) 
            {
                foreach (CharDeathSpawnPoint spawnpoint in spawnPoints) 
                {
                    if (spawnpoint.isAvailable)
                    {
                        other.transform.position = spawnpoint.transform.position;
                        break;
                    }
                }
            }
        }
    }
}
