using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public int playerCount;
    public int playersReady;
    bool sceneLoaded;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (playersReady == playerCount)
        {
            if (sceneLoaded == false)
            {
                SceneManager.LoadScene("Level1_Daniel");
                sceneLoaded = true;
            }
            
            gameObject.GetComponent<PlayerInputManager>().enabled = false;
            
        }
    }


    public void PlayerJoined()
    {
        playerCount++;
    }
}
