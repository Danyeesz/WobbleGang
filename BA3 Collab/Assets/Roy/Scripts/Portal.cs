using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform target;
    public float portalRadious=1f;
    public float pushForce = 600;
   
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Object" || other.tag == "Bomb")
        {
            float distance = Vector3.Distance(other.transform.position, this.transform.position); ;
            if (distance > portalRadious)
            {
                other.transform.position = target.position;
                //other.transform.rotation = target.rotation;
               
                if (other.GetComponent<Rigidbody>() != null)
                {
                    other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    other.GetComponent<Rigidbody>().AddForce(target.forward*pushForce, ForceMode.Impulse);
                }
            }
        }
       
       // Debug.Log("Something entered "+other.tag);
    }
}
