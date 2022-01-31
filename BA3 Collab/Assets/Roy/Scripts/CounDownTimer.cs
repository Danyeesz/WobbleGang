using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounDownTimer : MonoBehaviour
{
    public Text countTxt;
   
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<MenuManager>() != null)
        {
            FindObjectOfType<MenuManager>().GameStarted = false;
        }
        StartCoroutine(Countdown());
        
    }

    IEnumerator Countdown() 
    {
        countTxt.text = "3";
        yield return new WaitForSeconds(1);
        countTxt.text = "2";
        yield return new WaitForSeconds(1);
        countTxt.text = "1";
        yield return new WaitForSeconds(1);
        countTxt.text = "Let's Go!!";
        yield return new WaitForSeconds(.5f);
        if (FindObjectOfType<MenuManager>() != null)
        {
            FindObjectOfType<MenuManager>().GameStarted = true;
        }
    }
 
}
