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
    GameObject empty;
    public Animator targetAnimator;
    bool walk = false;
    public Animator _animatedAnimator;
    Transform _animatedTorso;



    public Transform GetAnimatedBone(HumanBodyBones bone)
    {
        return _animatedAnimator.GetBoneTransform(bone);
    }

    void Awake()
    {
        control = new PlayerControls();
        armature = transform.GetChild(0);
        hips = armature.GetChild(0);
        hipsr = hips.GetComponent<Rigidbody>();

        leftHand = GameObject.Find("Lowerarm.L").GetComponent<Rigidbody>();
        rightHand = GameObject.Find("Lowerarm.R").GetComponent<Rigidbody>();

        control.Movement.Jump.performed += ctx => Jump();
        control.Movement.Grab.performed += ctx => Grab();
        control.Movement.Grab.canceled += ctx => UnGrab();
       _animatedTorso =  _animatedAnimator.GetBoneTransform(HumanBodyBones.Hips);




    }

    private void OnEnable()
    {
        control.Movement.Enable();
    }

    private void OnDisable()
    {
        control.Movement.Disable();
    }

    public void Walk(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            move = value.ReadValue<Vector2>();
            

        }
        else if (value.canceled)
        {
            move = Vector2.zero;
            
        }

    }

    void Jump() 
    {

        if (isGrounded == true)
        {
            velocity.y = Mathf.Sqrt((2f * -2f * gravity));
            isGrounded = false;
            hipsr.AddForce(new Vector3(0,600,0));
        }

    }
    void Grab()
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

            }
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


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundC.transform.position, 0.4f, ground);

        Vector3 direction = new Vector3(move.x, 0f, move.y);
        if (direction.magnitude >= 0.1f) { 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            hipsr.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(0f, 0f, -targetAngle);
            hipsr.AddForce(direction * 20);
            walk = true;
        }
        else
        {
            walk = false;
        }
        targetAnimator.SetBool("Walk", walk);

        _animatedAnimator.transform.position = hips.position
                                + (_animatedAnimator.transform.position - _animatedTorso.position);
    }
}
