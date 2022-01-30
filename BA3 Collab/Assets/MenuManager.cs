using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public int playerCount;
    public int playersReady;
    public GameObject CharSelectionCam;
    public GameObject InGameCam;
    public bool GameStarted = false;

    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        if (playersReady == playerCount)
        {
            GameStarted = true;
            InGameCam.SetActive(true);
            CharSelectionCam.SetActive(false);
            playersReady++;
        }
    }


    public void PlayerJoined()
    {
        playerCount++;
    }
}
