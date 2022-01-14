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
    public float groundLength=2;
    public Vector3 startingPosition;
    private Vector3 curentPosition;
    private float groundHeight;


    public float timeTillNextChange;
    private float timeCountDown;
    void Start()
    {
        Transform[,] array2D = new Transform[rowSize,columnSize];
        positions2D = array2D;
        groundHeight = startingPosition.y;
        curentPosition = startingPosition;

        ArrangeTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ArrangeTiles() 
    {
        for (int row = 0; row < rowSize; row++) 
        {
            for (int column = 0; column < columnSize; column++)
            {
                Instantiate(groundTile, curentPosition, groundTile.transform.rotation);
                if (column == columnSize - 1)
                {
                    curentPosition = new Vector3(startingPosition.x, groundHeight, curentPosition.z);
                }
                else
                {
                    float x = curentPosition.x + groundLength;
                    curentPosition = new Vector3(x, groundHeight, curentPosition.z);
                }
            }
            float z = curentPosition.z - groundLength;
            curentPosition = new Vector3(curentPosition.x, groundHeight,z);
        }

    }

    void GenerateHoles() 
    {
        for (int i = 0; i < maxNoOfHoles; i++) 
        {
        
        }
    }
   
}
