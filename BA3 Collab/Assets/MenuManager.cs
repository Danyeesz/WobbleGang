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
    public GameObject UI_CharSelection;
    public bool GameStarted = false;
    public GameObject CountDown;
    public int RedPlayers;
    public int BluePlayers;

    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        if (playersReady == playerCount && playerCount != 0 && GameStarted==false)
        {
            
            GameStarted = true;
            InGameCam.SetActive(true);
            CharSelectionCam.SetActive(false);
            UI_CharSelection.SetActive(false);
            CountDown.SetActive(true);
            PlayerController_Daniel[] players = FindObjectsOfType<PlayerController_Daniel>();
            foreach (var item in players)
            {
                if (item.TeamLayer.layer == 13)
                {
                    RedPlayers++;
                }
                else if (item.TeamLayer.layer == 14)
                {
                    BluePlayers++;
                }
            }
            
           
           
           
        }
    }


    public void PlayerJoined()
    {
        playerCount++;
    }
}
