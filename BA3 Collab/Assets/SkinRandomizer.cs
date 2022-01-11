using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinRandomizer : MonoBehaviour
{

    public Material CharacterMat1;
    public Material CharacterMat2;
    public int random;

    // Start is called before the first frame update
    void Start()
    {

        random = Random.Range(0, 100);
        if (random == 0)
        {
            GetComponent<SkinnedMeshRenderer>().material = CharacterMat1;
        }
        else
        {
            GetComponent<SkinnedMeshRenderer>().material = CharacterMat2;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
