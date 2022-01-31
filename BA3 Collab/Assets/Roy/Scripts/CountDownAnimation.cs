using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CountDownAnimation : MonoBehaviour
{
    public bool timerEnded;
    public void StartGame() 
    {
        timerEnded = true;
        if (FindObjectOfType<BombManager>() != null) 
        {
            FindObjectOfType<BombManager>().startSpawn = true;
        }
        gameObject.SetActive(false);
    }

    private void Start()
    {
        timerEnded = false;

    }
}
