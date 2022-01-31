using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CountDownAnimation : MonoBehaviour
{
    public bool timerEnded;
    public void StartGame() 
    {
        timerEnded = true;
    }

    private void Start()
    {
        timerEnded = false;

    }
}
