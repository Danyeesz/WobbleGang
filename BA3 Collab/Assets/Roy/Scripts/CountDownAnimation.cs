using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CountDownAnimation : MonoBehaviour
{
    public bool timerEnded;
    public GameObject WinningZone;
    
    public void StartGame() 
    {
        timerEnded = true;
        if (FindObjectOfType<BombManager>() != null) 
        {
            FindObjectOfType<BombManager>().startSpawn = true;
        }
        if (FindObjectOfType<BombPipeSpawner>() != null)
        {
            FindObjectOfType<BombPipeSpawner>().startSpawning = true;
        }
        gameObject.SetActive(false);
        WinningZone.SetActive(true);

        PlayerController_Daniel [] players = FindObjectsOfType<PlayerController_Daniel>();
        foreach (var item in players)
        {
            item.enabled = true;
        }
    }

    private void Start()
    {
        timerEnded = false;

    }
}
