using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPipeSpawner : MonoBehaviour
{
    public GameObject bomb;
    public bool startSpawning;
    public float spawnInterval;
    public float fireRateInverse;
    public int maxAmountOfBombs;
    public int pushForce=300;
    float counter;
    // Start is called before the first frame update
    void Start()
    {
        startSpawning = false;
        counter = spawnInterval;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startSpawning == true)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                SpawnBomb();
                counter = spawnInterval;
            }
        }

    }

    void SpawnBomb() 
    {
        Grenade[] bombs = FindObjectsOfType<Grenade>();
        if (bombs.Length < maxAmountOfBombs)
        {
            Instantiate(bomb, transform.position, transform.rotation).GetComponent<Rigidbody>().AddForce(transform.forward * pushForce, ForceMode.Impulse);
            StartCoroutine(Delay());
            SpawnBomb();
        }
        else 
        {
            return;
        }

    }

    IEnumerator Delay() 
    {
        yield return new WaitForSeconds(fireRateInverse);
    }

    
}
