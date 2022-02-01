using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerController_Daniel : MonoBehaviour
{

    
    Vector2 move;
    public Vector3 velocity;
    public bool Grounded;
    public bool canGrab;
    public GameObject groundC;
    public LayerMask Ground;
    public LayerMask objects;
    Transform armature;
    Transform hips;
    public Transform grabPos;
    Rigidbody hipsr;
    public bool walk = false;
    public Animator _animatedAnimator;
    public Animator _physicalAnimator;
    public  Transform _animatedTorso;
    public Transform _physicalTorso;
    public GameObject toGrab;
    CharacterSelect CharSelect;
    GameObject GrabbedObject;
    public int speed;
    public GameObject TeamLayer;

    void Awake()
    {
        armature = transform.GetChild(0);
        hips = armature.GetChild(0);
        Debug.Log(hips);
        hipsr = hips.GetComponent<Rigidbody>();
        _animatedTorso =  _animatedAnimator.GetBoneTransform(HumanBodyBones.Hips);
        _physicalTorso = _physicalAnimator.GetBoneTransform(HumanBodyBones.Hips);
        CharSelect = gameObject.GetComponentInParent<CharacterSelect>(); 
        if (CharSelect.NumberOfPlayers == 1)
        {
            transform.position = GameObject.Find("Player1SpawnPos").transform.position;
        }
        else if (CharSelect.NumberOfPlayers == 2)
        {
            transform.position = GameObject.Find("Player2SpawnPos").transform.position;
        }
        else if (CharSelect.NumberOfPlayers == 3)
        {
            transform.position = GameObject.Find("Player3SpawnPos").transform.position;
        }
        else if (CharSelect.NumberOfPlayers == 4)
        {
            transform.position = GameObject.Find("Player4SpawnPos").transform.position;
        }
        if (CharSelect.TeamIndex == 1)
        {
            TeamLayer = gameObject.GetComponentsInChildren<Transform>().FirstOrDefault(c => c.gameObject.name == "lowerleg.R").gameObject;
            TeamLayer.layer = 13;
        }
        else if (CharSelect.TeamIndex == 0)
        {

           TeamLayer = gameObject.GetComponentsInChildren<Transform>().FirstOrDefault(c => c.gameObject.name == "lowerleg.R").gameObject;
            TeamLayer.layer = 14;
        }


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
    
    public void Grab(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            canGrab = Physics.CheckSphere(grabPos.transform.position, 2f, objects);
            if (canGrab == true)
            {
                Collider[] r_colliders = Physics.OverlapSphere(grabPos.transform.position, 0.5f, objects);
                foreach (Collider coll in r_colliders)
                {
                    if (coll.GetComponent<Grenade>() != null)
                    {
                        coll.GetComponent<Grenade>().ActivateBomb();
                    }
                    coll.gameObject.AddComponent<FixedJoint>();
                    coll.GetComponent<FixedJoint>().connectedBody = hipsr;
                    toGrab = coll.gameObject;
                    coll.transform.position = grabPos.position;
                    GrabbedObject = coll.gameObject;
                   

                }
            }
        }
        else if (value.canceled)
        {
            canGrab = true;
            UnGrab();
        }
        

    }

    void UnGrab() 
    {
        Debug.Log(GrabbedObject);
        if(GrabbedObject)
            Destroy(GrabbedObject.GetComponent<FixedJoint>());
        toGrab = null;
    }

    public void Special(InputAction.CallbackContext value)
    {
        Debug.Log(CharSelect.CharID);
        if (value.performed)
        {
            if (CharSelect.CharID==0)
            {
                speed = 1000;

            }
            else if(CharSelect.CharID == 1)
            {

            }
            else if (CharSelect.CharID == 2)
            {
                speed = 1000;
            }
            else if (CharSelect.CharID == 3)
            {
                speed = 300;
            }
            
        }
        else if (value.canceled)
        {
            speed = 600;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        Grounded = Physics.CheckSphere(groundC.transform.position, 1f, Ground);
        if (!Grounded)
        {
            
        }

        Vector3 direction = new Vector3(move.x, 0f, move.y);
        if (direction.magnitude >= 0.1f) { 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            hipsr.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(0f, 0f, -targetAngle);
            hipsr.velocity = (direction * speed)* Time.deltaTime;
            walk = true;
        }
        else
        {
            walk = false;
        }
        _animatedAnimator.SetBool("Walk", walk);
        _animatedAnimator.transform.position = _physicalTorso.position+ (_animatedAnimator.transform.position - _animatedTorso.position);
        _animatedAnimator.transform.rotation = _physicalTorso.rotation;

    }
}
