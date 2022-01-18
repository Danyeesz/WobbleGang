using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public int playerCount;

    // Start is called before the first frame update
    void Start()
    {
        playerCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PlayerJoined()
    {
        playerCount++;
    }
}
