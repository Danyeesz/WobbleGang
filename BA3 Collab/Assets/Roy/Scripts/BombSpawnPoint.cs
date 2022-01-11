using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawnPoint : MonoBehaviour
{
    public bool isAvailable=true;
    public float checkRadius = 1f;
    public LayerMask bombLayer;

    private void Start()
    {
        isAvailable = true;
    }

    private void Update()
    {
        isAvailable =! Physics.CheckSphere(transform.position, checkRadius, bombLayer);
    }

}
