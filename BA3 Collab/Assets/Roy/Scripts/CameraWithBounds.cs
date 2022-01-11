using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraWithBounds : MonoBehaviour
{
    GameObject[] players;
    public Vector3 offset;
    private Vector3 velocity;
    public float smoothTime = .5f;

    public float minZoom = 70f;
    public float maxZoom = 40f;
    public float zoomLimiter = 50f;

    private Camera cam;


    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        cam = GetComponent<Camera>();
    }


    private void LateUpdate()
    {
        if (players == null) 
        {
            //players = GameObject.FindGameObjectsWithTag("Player");
            return;
        }
        Move();
        Zoom();
       
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPosition();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom() 
    {
        float newZoom = Mathf.Lerp(minZoom,maxZoom,GreatestDistance()/15f);
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
