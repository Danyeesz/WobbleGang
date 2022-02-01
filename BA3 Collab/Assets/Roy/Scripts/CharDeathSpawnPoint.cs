using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDeathSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isAvailable;
    public LayerMask player;
    public float checkRadius=1f;
    // Update is called once per frame
    void Update()
    {
        isAvailable =!Physics.CheckSphere(transform.position,checkRadius,player);
        
    }
}
