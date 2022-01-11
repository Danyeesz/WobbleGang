using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevel_00 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] players;
    private Camera camera;

    public float zMax;
    public float zMin;
    public float zOffset;
    public float yMax;
    public float yMin;
    public float yOffset;
   

    private float zRange;
    public float zRangeMax = 45;
    public float zRangeMin = 13;
    private float yRange;

    public float xRotationMax; // Max/Min rotation corresponds to the max/min value of Z and Y cordinates, not the higher value of numbers 
    public float xRotationMin;

    public AnimationCurve cameraCurve;

    public Vector3 defaultPosition;




    public
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        camera = GetComponent<Camera>();

        //yRange = Mathf.Abs(yMax - yMin);
       // zRange = Mathf.Abs(zMax-zMin);
       // Debug.Log(players.Length);
    }

    // Update is called once per frame
    void Update()
    {

        SortByZvalueAccendingOrder();
        

        zRange =Mathf.Abs(players[players.Length - 1].transform.position.z - players[0].transform.position.z);
        
      

        float z = players[0].transform.position.z - ZOffset(zRange);
        float y = DetermineCameraY(zRange);

        //Debug.Log("z val: " + z + " y val: " + y + "z Range: " + zRange);
        //Vector3 avgPos = AveragePositionVector();
        //Vector3 target = new Vector3(9f, avgPos.y, (avgPos.z+players[0].transform.position.z)/2);
        //transform.LookAt(target);
        Vector3 cameraPosition = new Vector3(transform.position.x, y,z);

        transform.position = Vector3.Lerp(transform.position,cameraPosition,100f);
    }





    void SortByZvalueAccendingOrder()
    {
        for (int i = 0; i < (players.Length - 1); i++)
        {
            for (int j = 1; j < (players.Length); j++)
            {
                if (players[i].transform.position.z > players[j].transform.position.z)
                {
                    GameObject temp = players[i];
                    players[i] = players[j];
                    players[j] = temp;
                }
            }
        }
    }


    float DetermineCameraY(float zDifference) 
    {
        float y;
        y = yMin + (zDifference*yMax/100);

        if (zDifference <= 13)
        {
            y = 13f;
        }
        else if (zDifference > 13 && zDifference < 45)
        {
            y = yMin + ((zDifference / 100) * (yMax - yMin));

        }
        else
        {
            y = 31;

        }
     
        return y;
    }
    float DetermineCameraZ(float ZDifference) 
    {
        float z;
        if (ZDifference <= 13)
        {
            z = -4;
            
        }
        else if (ZDifference > 13 && ZDifference < 45)
        {
            z = players[0].transform.position.z - ZOffset(zRange);
            
        }
        else  
        {
            z = 31;
           
        }
        return z;

    }
    float ZOffset(float zDifference) 
    {
        float offset;

        offset = zOffset + (zDifference/100);
        return offset;
    
    }
    void SortByYvalueAccendingOrder()
    {
        for (int i = 0; i < (players.Length - 1); i++)
        {
            for (int j = 1; j < (players.Length); j++)
            {
                if (players[i].transform.position.y > players[j].transform.position.y)
                {
                    GameObject temp = players[i];
                    players[i] = players[j];
                    players[j] = temp;
                }
            }
        }
    }



    // Extras (not in use)*************************************************************************************************************


    Vector3 AveragePositionVector()
    {
        Vector3 avgPos = Vector3.zero;
        for (int i = 0; i < (players.Length - 1); i++)
        {
            avgPos += players[i].transform.position;
        }
        return avgPos / players.Length;
    }



    void SortByXvalue()
    {
        for (int i = 0; i < (players.Length - 2); i++)
        {
            for (int j = 1; j < (players.Length - 1); j++)
            {
                if (players[i].transform.position.x > players[j].transform.position.x)
                {
                    GameObject temp = players[i];
                    players[i] = players[j];
                    players[j] = temp;
                }
            }
        }
    }
    void SortByDistance()
    {
        for (int i = 0; i < (players.Length - 2); i++)
        {
            for (int j = 1; j < (players.Length - 1); j++)
            {
                if (Vector3.Distance(transform.position, players[i].transform.position) > Vector3.Distance(transform.position, players[j].transform.position))
                {
                    GameObject temp = players[i];
                    players[i] = players[j];
                    players[j] = temp;
                }
            }
        }

    }

    void SortByZDistance()
    {
        for (int i = 0; i < (players.Length - 2); i++)
        {
            for (int j = 1; j < (players.Length - 1); j++)
            {
                if (Mathf.Abs(players[i].transform.position.z - transform.position.z) > Mathf.Abs(players[j].transform.position.z - transform.position.z))
                {
                    GameObject temp = players[i];
                    players[i] = players[j];
                    players[j] = temp;
                }
            }
        }

    }

}
