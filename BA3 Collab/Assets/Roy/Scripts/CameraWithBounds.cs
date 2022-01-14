using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraWithBounds : MonoBehaviour
{
    public GameObject[] players;
    public Vector3 offset;
    private Vector3 velocity;
    public float smoothTime = .5f;

    public float minZoom = 70f;
    public float maxZoom = 50f;
    public float zoomLimiter = 50f;

    private Camera cam;


    void Start()
    {
       
        cam = GetComponent<Camera>();
    }


    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length==0)
        {
            //players = GameObject.FindGameObjectsWithTag("Player");
            return;
        }
        else
        {
            Move();
            Zoom();
        }
       
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPosition();
        Vector3 newPosition = centerPoint + offset;
        //Vector3 newCenterPos = new Vector3(transform.position.x, centerPoint.y, centerPoint.z);
        //Vector3 newPosition = newCenterPos + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom() 
    {
        float newZoom = Mathf.Lerp(maxZoom,minZoom,GreatestDistance()/zoomLimiter);
        cam.fieldOfView = newZoom;
    }

    float GreatestDistance() 
    {
        var bounds = new Bounds(players[0].transform.position, Vector3.zero);

        for (int i = 0; i < players.Length; i++)
        {
            bounds.Encapsulate(players[i].transform.position);
        }
        return bounds.size.z;
    }
    Vector3 GetCenterPosition() 
    {
        if (players.Length == 1)
        {
            return players[0].transform.position;
        }

        var bounds = new Bounds(players[0].transform.position, Vector3.zero);

        for (int i = 0; i < players.Length; i++) 
        {
            bounds.Encapsulate(players[i].transform.position);
        }

        return bounds.center;
    }
}
