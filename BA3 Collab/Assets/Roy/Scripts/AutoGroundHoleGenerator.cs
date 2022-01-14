using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGroundHoleGenerator : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject hole;
    public int maxNoOfHoles=3;
    public Transform[,] positions2D;
    public int rowSize;
    public int columnSize;
    public float groundLength=1;
    public Vector3 startingPosition;


    public float timeTillNextChange;
    private float timeCountDown;
    void Start()
    {
        Transform[,] array2D = new Transform[rowSize,columnSize];
        positions2D = array2D;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ArrangeTiles() 
    {
    
    }
}
