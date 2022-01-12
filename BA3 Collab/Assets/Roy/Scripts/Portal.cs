using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform target;
    public float portalRadious=1f;
    public float portalDelay = .4f;
    private float countdown;
    private bool isTransprtingPlayer = false;
    private Collider playerCollider;
    private void Update()
    {
        if (isTransprtingPlayer) 
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0) 
            {
                isTransprtingPlayer = false;
                playerCollider.transform.position = target.position;
                playerCollider.transform.rotation = target.rotation;
                
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        float distance = Vector3.Distance(other.transform.position, this.transform.position);
        if (distance > portalRadious)
        {
            if (other.tag == "Player")
            {
                isTransprtingPlayer = true;
                playerCollider = other;
                countdown = portalDelay;
            }
            else
            {
                other.transform.position = target.position;
                other.transform.rotation = target.rotation;             
            }
        }
       
       // Debug.Log("Something entered "+other.tag);
    }
}
