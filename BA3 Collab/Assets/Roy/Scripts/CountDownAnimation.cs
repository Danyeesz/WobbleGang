using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CountDownAnimation : MonoBehaviour
{
    public bool timerEnded;
    public void StartGame() 
    {
        timerEnded = true;
        this.enabled = false;
    }

    private void Start()
    {
        timerEnded = false;

    }
}
