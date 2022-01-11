using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delayTime;
    float countdown;
    public bool isActivated=false;
    bool isExploded=false;
    public GameObject explosionEffect;
    public float exlosionRadius;
    private void Start()
    {
        countdown = delayTime;
    }

    private void Update()
    {
        if (isActivated) 
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0 && !isExploded) 
            {
                Explode();
                isExploded = true;
            }
        }
    }

    public void ActivateBomb() 
    {
        isActivated = true;
    }
    void Explode() 
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        GiveDamage();
        Destroy(gameObject);
    }

    void GiveDamage() 
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,exlosionRadius);

        foreach (Collider collider in colliders) 
        {
            if (collider.GetComponent<BoxDestroyable>() != null) 
            {
                collider.GetComponent<BoxDestroyable>().GetHit();
            }
        }
    
    }
}
