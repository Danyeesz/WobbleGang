using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DummyController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDeviceRegained()
    {

    }
    void OnDeviceLost() 
    {

    }

    void OnControlsChanged() 
    {
    
    }

    void OnJump()
    {
        rb.velocity = Vector3.up * Time.deltaTime * jumpHeight;
        Debug.Log("jumping");
    }
}
