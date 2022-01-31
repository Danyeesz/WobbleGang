using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delayTime=9;
    float countdown;
    public bool isActivated=false;
    bool isExploded=false;
    public GameObject explosionEffect;
    public float exlosionRadius;

    // automatic blast after 9 sec, no activation needed. first 6 sec normal, 7-9 flicker.. blow up at 9. 
    private void Start()
    {
        isActivated = true;
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
