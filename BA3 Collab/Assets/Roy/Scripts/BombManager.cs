using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public int totalBomb=3;
    public float spawnInterval;
    float countdown=5f;
    public GameObject bomb;
    public BombSpawnPoint[] bombSpawnPoints;
    void Start()
    {
        bombSpawnPoints = FindObjectsOfType<BombSpawnPoint>();
        countdown = spawnInterval;
    }

 
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0) 
        {
            SpawnBomb();
            countdown = spawnInterval;
        }
    }

    void SpawnBomb() 
    {
        foreach (BombSpawnPoint spawnPoint in bombSpawnPoints) 
        {
            if (spawnPoint.isAvailable) 
            {
                Grenade[] bombs = FindObjectsOfType<Grenade>();
                if (bombs.Length < totalBomb)
                {

                    Instantiate(bomb, spawnPoint.transform.position, spawnPoint.transform.rotation);
                }
            }
        }

/*
        for (int i = 0; i < bombSpawnPoints.Length; i++) 
        {
            if (bombSpawnPoints[i].isAvailable) 
            {
                
            }
        }
    */
    }
}