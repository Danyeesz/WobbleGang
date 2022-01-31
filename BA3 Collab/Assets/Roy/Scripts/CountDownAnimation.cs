using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CountDownAnimation : MonoBehaviour
{
    public void StartGame() 
    {
        PlayerInput[] playerInputs = FindObjectsOfType<PlayerInput>();

        for (int i = 0; i < playerInputs.Length; i++)
        {
            playerInputs[i].enabled = true;
        }
    }

    private void Start()
    {
        PlayerInput[] playerInputs = FindObjectsOfType<PlayerInput>();
       
        for (int i = 0; i < playerInputs.Length; i++) 
        {
            playerInputs[i].enabled = false;
        }

    }
}
