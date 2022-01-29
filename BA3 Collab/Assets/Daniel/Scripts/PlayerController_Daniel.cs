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
    public bool canGrab;
    public GameObject groundC;
    public LayerMask ground;
    public LayerMask objects;
    CharacterController player;
    PlayerControls control;
    Transform armature;
    Transform hips;
    public Transform grabPos;
    Rigidbody hipsr;
    bool walk = false;
    public Animator _animatedAnimator;
    public Animator _physicalAnimator;
    Transform _animatedTorso;
    Transform _physicalTorso;
    public GameObject toGrab;
    public GameObject Lighty;
    public GameObject Strongy;
    public GameObject Speedy;
    public GameObject Breaky;
    GameObject MenuManager;
    GameObject GameController;
    CharacterSelect CharSelectP1;
    CharacterSelect CharSelectP2;
    CharacterSelect CharSelectP3;
    CharacterSelect CharSelectP4;
    GameObject GrabbedObject;



    void Awake()
    {
        control = new PlayerControls();
        armature = transform.GetChild(0);
        hips = armature.GetChild(0);
        hipsr = hips.GetComponent<Rigidbody>();
        _animatedTorso =  _animatedAnimator.GetBoneTransform(HumanBodyBones.Hips);
        _physicalTorso = _physicalAnimator.GetBoneTransform(HumanBodyBones.Hips);
        MenuManager = GameObject.Find("MenuManager");
        GameController = GameObject.Find("GameController");
        
       if (MenuManager.GetComponent<MenuManager>().playerCount == 1)
        {
            CharSelectP1 = GameObject.Find("Player(Clone) 1").GetComponent<CharacterSelect>();
        }
        else if (MenuManager.GetComponent<MenuManager>().playerCount == 2)
        {
            CharSelectP1 = GameObject.Find("Player(Clone) 1").GetComponent<CharacterSelect>();
            CharSelectP2 = GameObject.Find("Player(Clone) 2").GetComponent<CharacterSelect>();
        }
        else if (MenuManager.GetComponent<MenuManager>().playerCount == 3)
        {
            CharSelectP3 = GameObject.Find("Player(Clone) 3").GetComponent<CharacterSelect>();
        }
        else if (MenuManager.GetComponent<MenuManager>().playerCount == 4)
        {
            CharSelectP4 = GameObject.Find("Player(Clone) 4").GetComponent<CharacterSelect>();
        }
        


       
      

        if (Gamepad.all[0].deviceId == CharSelectP1.joyId)
        {
            Debug.Log(Gamepad.all[0].deviceId);
            if (CharSelectP1.CharID == 0)
            {
                Lighty.SetActive(true);
            }
            else if (CharSelectP1.CharID == 1)
            {
                Lighty.SetActive(false);
                Strongy.SetActive(true);
            }
            else if (CharSelectP1.CharID == 2)
            {
                Debug.Log("Swifty Selected");
                Lighty.SetActive(false);
                Speedy.SetActive(true);
            }
            else if (CharSelectP1.CharID == 3)
            {
                Lighty.SetActive(false);
            }
        }
        else if (Gamepad.all[0].deviceId == CharSelectP2.joyId)
        {
            Debug.Log(Gamepad.all[0].deviceId);
            if (CharSelectP2.CharID == 0)
            {
                Lighty.SetActive(true);
            }
            else if (CharSelectP2.CharID == 1)
            {
                Lighty.SetActive(false);
                Strongy.SetActive(true);
            }
            else if (CharSelectP2.CharID == 2)
            {
                Lighty.SetActive(false);
            }
            else if (CharSelectP1.CharID == 3)
            {
                Lighty.SetActive(false);
            }
        }

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

    public void Jump(InputAction.CallbackContext value) 
    {
        if (value.performed)
        {
            if (isGrounded == true)
            {
                velocity.y = Mathf.Sqrt((2f * -2f * gravity));
                isGrounded = false;
                hipsr.AddForce(new Vector3(0, 6000, 0));
            }
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

        Destroy(GrabbedObject.GetComponent<FixedJoint>());
        toGrab = null;
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundC.transform.position, 0.4f, ground);

        Vector3 direction = new Vector3(move.x, 0f, move.y);
        if (direction.magnitude >= 0.1f) { 
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            hipsr.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(0f, 0f, -targetAngle);
            hipsr.AddForce(direction * 10000 *Time.deltaTime);
            walk = true;
        }
        else
        {
            walk = false;
        }
        _animatedAnimator.SetBool("Walk", walk);

        _animatedAnimator.transform.position = _physicalTorso.position
                                + (_animatedAnimator.transform.position - _animatedTorso.position);
        _animatedAnimator.transform.rotation = _physicalTorso.rotation;
                               
    }
}
