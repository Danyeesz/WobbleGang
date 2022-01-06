using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Daniel : MonoBehaviour
{

    
    Vector2 move;
    public Vector3 velocity;
    float gravity = -9.81f;
    public bool isGrounded;
    public bool rightHandGrab;
    public bool leftHandGrab;
    public GameObject groundC;
    public LayerMask ground;
    public LayerMask objects;
    CharacterController player;
    PlayerControls control;
    Transform armature;
    Transform hips;
    public Transform righthandpos;
    public Transform lefthandpos;
    Rigidbody rightHand;
    Rigidbody leftHand;
    Rigidbody hipsr;
    Rigidbody spine;
    GameObject empty;
    

    void Awake()
    {
        control = new PlayerControls();
        armature = transform.GetChild(0);
        hips = armature.GetChild(0);
        hipsr = hips.GetComponent<Rigidbody>();


        leftHand = GameObject.Find("Lowerarm.L").GetComponent<Rigidbody>();
        rightHand = GameObject.Find("Lowerarm.R").GetComponent<Rigidbody>();

      

        spine = GameObject.Find("Spine.002").GetComponent<Rigidbody>();
        
    }

    private void OnEnable()
    {
        control.Movement.Enable();
    }

    private void OnDisable()
    {
        control.Movement.Disable();
    }

    public void Jump(InputAction.CallbackContext value) 
    {

        if (isGrounded == true)
        {
            velocity.y = Mathf.Sqrt((2f * -2f * gravity));
            hipsr.AddForce(new Vector3(0,600,0));
            isGrounded = false;
            
        }

    }
    public void Grab(InputAction.CallbackContext value)
    {

        rightHandGrab = Physics.CheckSphere(righthandpos.transform.position, 0.2f, objects);
        if (rightHandGrab==true)
        {
            Collider[] r_colliders = Physics.OverlapSphere(righthandpos.transform.position, 0.5f, objects);
            foreach (Collider coll in r_colliders)
            {
                
                coll.gameObject.AddComponent<FixedJoint>();
                coll.GetComponent<FixedJoint>().connectedBody = rightHand;

            }
         
        }
        leftHandGrab = Physics.CheckSphere(lefthandpos.transform.position, 0.5f, objects);
        if (leftHandGrab == true)
        {
            Collider[] r_colliders = Physics.OverlapSphere(lefthandpos.transform.position, 0.5f, objects);
            foreach (Collider coll in r_colliders)
            {

                coll.gameObject.AddComponent<FixedJoint>();
                coll.GetComponent<FixedJoint>().connectedBody = leftHand;
                coll.transform.position = righthandpos.position;
                coll.GetComponent<FixedJoint>().connectedBody = spine;
                //R_upper.GetComponent<ConfigurableJoint>().targetPosition = new Vector3(-0.000289999996f, 0.0080500003f, -0.00178000005f);
               

            }
               
            }
        if (value.canceled)
        {
            UnGrab();
            Debug.Log("ELENGEDVE");
        }
    }
      
    void UnGrab() 
    {
        rightHandGrab = Physics.CheckSphere(righthandpos.transform.position, 0.5f, objects);
        if (rightHandGrab == true)
        {
            Collider[] r_colliders = Physics.OverlapSphere(righthandpos.transform.position, 0.5f, objects);
            foreach (Collider coll in r_colliders)
            {
                Destroy(coll.GetComponent<FixedJoint>());
                rightHandGrab = false;


            }

        }
        
        leftHandGrab = Physics.CheckSphere(lefthandpos.transform.position, 0.5f, objects);
        if (leftHandGrab == true)
        {
            Collider[] r_colliders = Physics.OverlapSphere(lefthandpos.transform.position, 0.5f, objects);
            foreach (Collider coll in r_colliders)
            {

                Destroy(coll.GetComponent<FixedJoint>());

            }
        }


    }
    public void onWalk(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
        if (value.canceled)
        {
            move = Vector2.zero;
        }
        
                
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundC.transform.position, 0.4f, ground);

        Vector3 direction = new Vector3(move.x, 0f, move.y);

        //float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //hipsr.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        hipsr.AddForce(direction * 20);
    }
}
