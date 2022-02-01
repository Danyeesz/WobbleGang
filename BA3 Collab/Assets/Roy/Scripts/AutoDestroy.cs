using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float autoDestroyTime;
    void Update()
    {
        autoDestroyTime -= Time.deltaTime;
        if (autoDestroyTime < 0) 
        {
            Destroy(gameObject);
        }
    }
}
