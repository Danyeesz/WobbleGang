using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawnPoint : MonoBehaviour
{
    public bool isAvailable=true;

    private void Start()
    {
        isAvailable = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bomb") 
        {
            isAvailable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bomb") 
        {
            isAvailable = true;
        }
    }
}
