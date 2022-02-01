using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delayTime = 9;
    float countdown;
    public bool isActivated = false;
    bool isExploded = false;
    public GameObject explosionEffect;
    public float exlosionRadius;
    public float explosionForce = 50f;
    public GameObject flickerLight;

    // automatic blast after 9 sec, no activation needed. first 6 sec normal, 7-9 flicker.. blow up at 9. 

    public float flickeringTime;
    public float flickeringRateInverse = .25f;
    bool isFlickering = false;

    public GameObject explosionSound;
    private void Start()
    {
        isActivated = true;
        isFlickering = false;
        countdown = delayTime;
        flickerLight.SetActive(false);
    }

    private void Update()
    {
        if (isActivated)
        {
            countdown -= Time.deltaTime;
            if (countdown <= flickeringTime)
            {
                if (!isFlickering)
                {
                    isFlickering = true;
                    StartCoroutine(Flicker());
                }
                if (countdown <= 0 && !isExploded)
                {
                    Explode();
                    isExploded = true;
                }
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
        Instantiate(explosionSound,transform.position,transform.rotation);
        GiveDamage();
        Destroy(gameObject);
    }

    void GiveDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, exlosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<BoxDestroyable>() != null)
            {
                collider.GetComponent<BoxDestroyable>().GetHit();
            }

            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, exlosionRadius);
            }
        }

    }
    IEnumerator Flicker()
    {
        flickerLight.SetActive(true);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(false);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(true);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(false);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(true);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(false);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(true);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(false);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(true);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(false);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(true);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(false);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(true);
        yield return new WaitForSeconds(flickeringRateInverse);
        flickerLight.SetActive(false);
    }
}
