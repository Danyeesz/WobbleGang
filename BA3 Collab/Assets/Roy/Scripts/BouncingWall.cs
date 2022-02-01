using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingWall : MonoBehaviour
{
    public float reflectionForce = 20000f;
    public GameObject bounceSound;
    public Transform[] reflectors;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>()!=null && (collision.gameObject.tag=="Player" ||collision.gameObject.tag == "Bomb" || collision.gameObject.tag == "Object"))
        {
            
            
            Vector3 direction = NearestReflector(collision.gameObject.transform.position).forward;
            Instantiate(bounceSound, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * reflectionForce, ForceMode.Impulse);


        }
    }

    Transform NearestReflector(Vector3 objPosition) 
    {
        for (int i = 0; i < reflectors.Length-1; i++) 
        {
            for (int j = 1; j < reflectors.Length; j++) 
            {
                if (Vector3.Distance( reflectors[i].position,objPosition) > Vector3.Distance( reflectors[j].position,objPosition)) 
                {
                    Transform temp = reflectors[i];
                    reflectors[i] = reflectors[j];
                    reflectors[j] = temp;
                }
            }
        }

        return reflectors[0];
    }

   
}
