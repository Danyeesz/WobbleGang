using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovementObjObj : MonoBehaviour
{
    public float timeTillNextRoation = 1f;
    float counter;
    public float speed = 2f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        counter = timeTillNextRoation;
    }

    // Update is called once per frame
    void Update()
    {
        counter-= Time.deltaTime;
        if (counter <= 0)
        {
            //Vector3 rotationEuler = new Vector3(transform.rotation.x, Random.Range(30f, 90f), transform.rotation.z);
            transform.Rotate(transform.rotation.x, Random.Range(30f, 90f), transform.rotation.z);
            rb.AddForce(transform.forward*speed, ForceMode.Impulse);
            counter = timeTillNextRoation;
        }
    }
}
