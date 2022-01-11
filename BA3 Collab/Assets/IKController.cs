using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKController : MonoBehaviour
{

    protected Animator animator;

    public bool ikActive = false;
    public GameObject ObjToGrab = null;
    public bool grab;
    public PlayerController_Daniel controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        grab = controller.canGrab;
        ObjToGrab = controller.toGrab;
    }
    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            if ( grab == true)
            {
                
                // Set the right hand target position and rotation, if one has been assigned
                if (ObjToGrab != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, ObjToGrab.transform.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, ObjToGrab.transform.rotation);
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, ObjToGrab.transform.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, ObjToGrab.transform.rotation);
                }
            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0); 
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                ObjToGrab = null;
               
            }
        }
    }
}