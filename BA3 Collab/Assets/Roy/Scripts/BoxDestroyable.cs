using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroyable : MonoBehaviour
{
    public int hitCount = 2;
    public ParticleSystem destroyParticle;
    bool destroyed = false;

   
    public GameObject brokenBox;

    private void Start()
    {
        if (brokenBox != null) brokenBox.SetActive(false);
    }

    public void GetHit() 
    {
        if (!destroyed) 
        {
            hitCount -= 1;
            GetComponent<MeshRenderer>().enabled = false;
            if (brokenBox != null) 
            {
                brokenBox.SetActive(true);
                brokenBox.GetComponent<MeshRenderer>().enabled = true;
            }
            if (hitCount <= 0)
            {
                destroyed = true;
                if (brokenBox != null) brokenBox.SetActive(false);
                Instantiate(destroyParticle, transform.position, transform.rotation);
                Destroy(gameObject);

            }
           
        }
    } 
}
