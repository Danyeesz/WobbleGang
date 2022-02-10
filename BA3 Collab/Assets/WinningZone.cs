using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningZone : MonoBehaviour
{

    int RedCounter;
    int BlueCounter;
    public GameObject RedWin;
    public GameObject BlueWin;

    MenuManager GameManager;
    bool GameWon = false;


    private void Start()
    {
        GameManager = GameObject.FindObjectOfType<MenuManager>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            RedCounter++;
            other.gameObject.GetComponentInParent<PlayerController_Daniel>().enabled = false;
            other.gameObject.GetComponentInParent<Animator>().enabled = false;

        }
        else if (other.gameObject.layer == 14)
        {
            BlueCounter++;
            other.gameObject.GetComponentInParent<PlayerController_Daniel>().enabled = false;
            other.gameObject.GetComponentInParent<Animator>().enabled = false;

        }
    }

    public void Update()
    {
        if (!GameWon)
        {
            if (RedCounter == GameManager.RedPlayers && RedCounter != 0)
            {
                GameWon = true;
                RedWin.SetActive(true);
               
            }
            else if (BlueCounter == GameManager.BluePlayers && BlueCounter != 0)
            {
                GameWon = true;
                BlueWin.SetActive(true);
                
            }
        }
        if (GameWon)
        {
            Transform.FindObjectOfType<PlayerController_Daniel>().enabled = false;
            
        }
       
    }

  
}
